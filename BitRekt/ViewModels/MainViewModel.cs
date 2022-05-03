using BitMexAPI.Client;
using BitMexAPI.Json;
using BitMexAPI.Requests.Rest;
using BitMexAPI.Requests.Websocket;
using BitMexAPI.Responses;
using BitMexAPI.Responses.Instruments;
using BitMexAPI.Responses.Orders;
using BitMexAPI.Responses.Positions;
using BitMexAPI.Rest;
using BitMexAPI.Utils;
using BitMexAPI.Websocket;
using ReactiveUI;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

// To change environments
// Change BitmexRestClient (VM and Class)
// Change BitmexWebsocketCommunicator (VM)
// Change SendSubscriptionRequests
// Change RestRequestBase

namespace BitRekt.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private static readonly string API_KEY = "Pzyl8N6APkJAYh1595Tj-K5R";
        private static readonly string API_SECRET = "QLMXw_AxUkJduLRycPmvBn_JPYBOzv_-TrA0nDuHGGmdWgBX";

        private static string testKey = "TId8wVxpfPlPq7HIK7PsBnTs";
        private static string testSecret = "OLBgWriMZrInh_AO3D6ZvXaKwyNwqjrwy0rFAdXMcuaDod-S";

        private string domain = "https://www.bitmex.com";

        private readonly BitmexRestClient restClient;

        private readonly ObservableAsPropertyHelper<string> _walletString;
        public string WalletString => _walletString.Value;

        private readonly ObservableAsPropertyHelper<string> _DateString;
        public string DateString => _DateString.Value;

        private ReactiveList<Position> _positions;
        public ReactiveList<Position> Positions
        {
            get => _positions ?? (_positions = new ReactiveList<Position>());
            set => this.RaiseAndSetIfChanged(ref _positions, value);
        }

        public Position ActivePosition { get; set; }

        private ReactiveList<Instrument> _instruments;
        public ReactiveList<Instrument> Instruments
        {
            get => _instruments ?? (_instruments = new ReactiveList<Instrument>());
            set => this.RaiseAndSetIfChanged(ref _instruments, value);
        }

        public Instrument ActiveInstrument { get; set; }

        public ReactiveCommand TakeProfitCommand { get; set; }

        public MainViewModel()
        {
            InitLogging();

            Positions.ChangeTrackingEnabled = true;

            _DateString = Observable.Interval(TimeSpan.FromMilliseconds(1000))
                .Select(_ => DateTime.UtcNow)
                .Select(now => $"{now.ToShortDateString()} {now.ToLongTimeString()}")
                .ToProperty(this, x => x.DateString, scheduler: RxApp.MainThreadScheduler);

            restClient = new BitmexRestClient(API_KEY, API_SECRET);

            REQ(restClient);

            //var communicator = new BitmexWebsocketCommunicator(BitmexValues.ApiWebsocketUrl);
            var communicator = new BitmexWebsocketCommunicator(BitmexValues.ApiWebsocketUrl);

            communicator.ReconnectTimeoutMs = (int)TimeSpan.FromSeconds(30).TotalMilliseconds;
            communicator.ReconnectionHappened.Subscribe(type =>
                Log.Information($"Reconnection happened, type: {type}"));

            var client = new BitmexWebsocketClient(communicator);

            client.Streams.InfoStream.Subscribe(async info =>
            {
                Log.Information($"Reconnection happened, Message: {info.Info}, Version: {info.Version:D}");
                await SendSubscriptionRequests(client);
            });

            SubscribeToStreams(client);

            _walletString = client.Streams.WalletStream
                .Select(response => response.Data.ToList().FirstOrDefault())
                .Select(wallet =>
                {
                    Log.Information($"Wallet {wallet.Account}, {wallet.Currency} amount: {wallet.BalanceBtc}");
                    string usd = (wallet.BalanceBtc * 6488).ToString("C", new CultureInfo("en-US"));
                    var str = $"Balance: {wallet.BalanceBtc} {wallet.Currency} - {usd}    |";
                    return str;
                })
                .ToProperty(this, x => x.WalletString);
            
            communicator.Start();

            TakeProfitCommand = ReactiveCommand.CreateFromTask(t => TakeProfitAsync());
            TakeProfitCommand.ThrownExceptions.Subscribe(e => Log.Error(e.Message));

            //var orderBook = "/" + Function.OrderBook.ToString().ToCamelCase();
            //var funding = "/" + Function.Funding.ToString().ToCamelCase();

            Order order1 = new Order()
            {
                Symbol = "XBTUSD",
                Side = BitmexSide.Sell,
                OrderQty = 1,
                Price = 7000,
                ExecInst = "ParticipateDoNotInitiate"
            };

            //Position pos1 = new Position()
            //{
            //    Symbol = "XBTUSD",
            //    CurrentQty = 1000,
            //    AvgEntryPrice = 6600,
            //    MarkPrice = 6611,
            //    LiquidationPrice = 4516,
            //    PosMargin = 50,
            //    UnrealisedPnl = 4,
            //    RealisedPnl = 1
            //};

            //ReqAsync(rest, client);

            //Profit(rest);
        }

        // Take profit button
        private async Task TakeProfitAsync()
        {
            // Get current position in active instrument
            // Get the entry price
            // find the division of the spread to determine divisions (every $10/0.14%)
            // Divide current position size by the modulus (if 1000 contracts and $20 spread, 2 500 contract orders)
            // Create new limit orders in opposite direction 
            // Add null check

            //ActivePosition = new Position()
            //{
            //    Symbol = "XBTUSD",
            //    CurrentQty = 10,
            //    AvgEntryPrice = 7000,
            //    MarkPrice = 6611,
            //    LiquidationPrice = 4516,
            //    PosMargin = 50,
            //    UnrealisedPnl = 4,
            //    RealisedPnl = 1
            //};

            //int divisions = 20 / 10;
            int divisions = 2;

            //var orderSize = Math.Abs((ActivePosition?.CurrentQty / divisions).Value);
            var orderSize = ActivePosition?.CurrentQty / divisions;
            var remainder = ActivePosition?.CurrentQty % divisions;

            // If Long, Make sell orders and vice versa
            var side = (ActivePosition?.CurrentQty > 0) ? BitmexSide.Sell : BitmexSide.Buy;

            var price = ActivePosition?.AvgEntryPrice ?? ActivePosition?.AvgCostPrice;

            var orderList = new List<Order>();

            for(int i = 0; i < divisions; i++)
            {
                // price * spread
                //price *= 1.0014;

                // Currently Long
                if (side == BitmexSide.Sell)
                    price *= 1.0014;
                else
                    price *= 0.9986;

                var roundedPrice = Round(price.Value);

                var x = new Order()
                {
                    Symbol = ActivePosition.Symbol,
                    Side = side,
                    OrderQty = i == 0 ? Convert.ToInt64(orderSize + remainder) : Convert.ToInt64(orderSize),
                    Price = roundedPrice,
                    OrdType = "Limit",
                    ExecInst = "ReduceOnly,ParticipateDoNotInitiate",
                    //ExecInst = "ParticipateDoNotInitiate",            
                };

                orderList.Add(x);

                Log.Debug("t");
            }

            var request = new LimitOrderBulkRequest(orderList.ToArray());
            var response = await restClient.ExecuteHttp(request);
            Log.Debug(response);
        }

        // Instruments set, Do Instrument stuff here
        private async void REQ(BitmexRestClient rest)
        {
            var request = new InstrumentRequest(true);
            var response = await rest.ExecuteHttp(request);

            var orderedList = BitmexJsonSerializer.Deserialize<ReactiveList<Instrument>>(response).OrderByDescending(i => i.Volume24h);

            foreach(var instrument in orderedList)
            {
                _instruments.Add(instrument);
                //await client.Send(new InstrumentSubscribeRequest(instrument.Symbol));
            }

            Log.Debug("Test");
        }

        public static double Round(double d)
        {
            var absoluteValue = Math.Abs(d);
            var integralPart = (long)absoluteValue;
            var decimalPart = absoluteValue - integralPart;
            var sign = Math.Sign(d);

            double roundedNumber;

            if (decimalPart > 0.5)
            {
                roundedNumber = integralPart + 1;
            }
            else if (decimalPart == 0)
            {
                roundedNumber = absoluteValue;
            }
            else
            {
                roundedNumber = integralPart + 0.5;
            }

            return sign * roundedNumber;
        }

        private static async Task SendSubscriptionRequests(BitmexWebsocketClient client)
        {
            await client.Send(new PingRequest());
            //await client.Send(new BookSubscribeRequest("XBTUSD"));
            //await client.Send(new TradesSubscribeRequest("XBTUSD"));
            //await client.Send(new TradeBinSubscribeRequest("1m", "XBTUSD"));
            //await client.Send(new TradeBinSubscribeRequest("5m", "XBTUSD"));
            //await client.Send(new QuoteSubscribeRequest("XBTUSD"));
            //await client.Send(new LiquidationSubscribeRequest());
            //await client.Send(new InstrumentSubscribeRequest("XBTUSD"));

            if (!string.IsNullOrWhiteSpace(API_KEY))
                await client.Authenticate(API_KEY, API_SECRET);
        }

        private void SubscribeToStreams(BitmexWebsocketClient client)
        {
            client.Streams.ErrorStream.Subscribe(x =>
                Log.Warning($"Error received, message: {x.Error}, status: {x.Status}"));

            client.Streams.AuthenticationStream.Subscribe(async x =>
            {
                Log.Information($"Authentication happened, success: {x.Success}");
                if (x.Success)
                {
                    await client.Send(new WalletSubscribeRequest());
                    await client.Send(new OrderSubscribeRequest());
                    await client.Send(new PositionSubscribeRequest());
                }
            });

            client.Streams.SubscribeStream.Subscribe(x =>
                Log.Information($"Subscribed ({x.Success}) to {x.Subscribe}"));

            client.Streams.PongStream.Subscribe(x =>
                Log.Information($"Pong received ({x.Message})"));

            client.Streams.InstrumentStream.Subscribe(y =>
                y.Data.ToList().ForEach(x =>
                {
                    // Update BTC last price
                    if(x.Symbol == "XBTUSD")
                    {
                        if(x.LastPrice.HasValue)
                        {

                        }
                    }
                }
            ));

            Log.Debug("test");

            client.Streams.OrderStream.Subscribe(y =>
                y.Data.ToList().ForEach(x =>
                    Log.Information(
                        $"Order {x.Symbol} updated. Time: {x.Timestamp:HH:mm:ss.fff}, Amount: {x.OrderQty}, " +
                        $"Price: {x.Price}, Direction: {x.Side}, Working: {x.WorkingIndicator}, Status: {x.OrdStatus}"))
            );

            var posComparer = new PositionComparer();

            //y.Data.ToList().Where(pos => pos.CurrentQty != 0).ToList().ForEach(x =>
            client.Streams.PositionStream.Subscribe(y =>
                y.Data.ToList().ForEach(x =>
                {
                    if (!_positions.Contains(x, posComparer) && x.IsOpen.HasValue && x.IsOpen.GetValueOrDefault())
                    {
                        _positions.Add(x);
                    }

                    if(_positions.Contains(x, posComparer))
                    {
                        var pls = _positions.Where(val => val.Symbol == x.Symbol).FirstOrDefault();
                        var index = _positions.IndexOf(pls);

                        if(x.IsOpen.HasValue)
                            _positions[index].IsOpen = x.IsOpen;

                        if (!_positions[index].IsOpen.Value)
                            _positions.RemoveAt(index);
                        else
                        {
                            _positions[index].CurrentQty = x.CurrentQty;
                            _positions[index].AvgEntryPrice = x.AvgEntryPrice;
                            _positions[index].MarkPrice = x.MarkPrice;
                            _positions[index].LiquidationPrice = x.LiquidationPrice;
                            _positions[index].PosMargin = x.PosMargin;
                            _positions[index].UnrealisedPnl = x.UnrealisedPnl;
                            _positions[index].RealisedPnl = x.RealisedPnl;

                            if(ActiveInstrument.Symbol == x.Symbol)
                                ActivePosition = _positions[index];
                        }
                    }
                 
                    Log.Information(
                        $"Position {x.Symbol}, {x.Currency} updated. Time: {x.Timestamp:HH:mm:ss.fff}, Amount: {x.CurrentQty}, " +
                        $"Price: {x.LastPrice}, PNL: {x.UnrealisedPnl}");
                })
            );

            client.Streams.TradesStream.Subscribe(y =>
                y.Data.ToList().ForEach(x =>
                    Log.Information($"Trade {x.Symbol} executed. Time: {x.Timestamp:mm:ss.fff}, Amount: {x.Size}, " +
                                    $"Price: {x.Price}, Direction: {x.TickDirection}"))
            );

            client.Streams.BookStream.Subscribe(book =>
                book.Data.Take(100).ToList().ForEach(x => Log.Information(
                    $"Book | {book.Action} pair: {x.Symbol}, price: {x.Price}, amount {x.Size}, side: {x.Side}"))
            );

            client.Streams.QuoteStream.Subscribe(y =>
                y.Data.ToList().ForEach(x =>
                    Log.Information($"Quote {x.Symbol}. Bid: {x.BidPrice} - {x.BidSize} Ask: {x.AskPrice} - {x.AskSize}"))
            );

            client.Streams.LiquidationStream.Subscribe(y =>
                y.Data.ToList().ForEach(x =>
                    Log.Information(
                        $"Liquadation Action:{y.Action} OrderID:{x.OrderID} Symbol:{x.Symbol} Side:{x.Side} Price:{x.Price} leavesQty:{x.leavesQty}"))
            );

            client.Streams.TradeBinStream.Subscribe(y =>
                y.Data.ToList().ForEach(x =>
                Log.Information($"TradeBin Table:{y.Table} {x.Symbol} executed. Time: {x.Timestamp:mm:ss.fff}, Open: {x.Open}, " +
                        $"Close: {x.Close}, Volume: {x.Volume}"))
            );
        }

        private static void InitLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(LogEventLevel.Information)
                .CreateLogger();
        }
    }
}