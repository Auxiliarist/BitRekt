using BitMexAPI.Json;
using BitMexAPI.Responses;
using BitMexAPI.Responses.Orders;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BitMexAPI.Requests.Rest
{
    public class LimitOrderRequest : RestRequestBase
    {
        public BitmexSymbol Symbol { get; }
        public BitmexSide Side { get; }
        public double Quantity { get; }
        public decimal Price { get; }
        public bool ReduceOnly { get; }
        public bool PostOnly { get; }
        public bool Hidden { get; }

        private readonly Order Order;

        public LimitOrderRequest(BitmexSymbol symbol, BitmexSide side, double quantity, decimal price, bool reduceOnly = false, bool postOnly = false, bool hidden = false)
        {
            Symbol = symbol;
            Side = side;
            Quantity = quantity;
            Price = price;
            ReduceOnly = reduceOnly;
            PostOnly = postOnly;
            Hidden = hidden;

            BuildParameters();
        }

        public LimitOrderRequest(Order order)
        {
            Order = order;

            BuildParameters();
        }

        public override bool RequiresAuth => true;

        protected override HttpMethod MethodType => HttpMethod.Post;
        public override string Path => "/api/v1/order";

        public override void BuildParameters()
        {
            base.BuildParameters();

            if (Order != null)
            {
                Json = BitmexJsonSerializer.Serialize(Order);

                Content = new StringContent(Json, Encoding.UTF8, "application/json");
            }
            else
            {
                Dictionary<string, string> param = new Dictionary<string, string>
                {
                    ["symbol"] = Symbol.ToString(),
                    ["side"] = Side.ToString(),
                    ["orderQty"] = Quantity.ToString(),
                    ["ordType"] = "Limit",
                    ["price"] = Price.ToString()
                };

                if (ReduceOnly && !PostOnly)
                {
                    param["execInst"] = "ReduceOnly";
                }
                else if (!ReduceOnly && PostOnly)
                {
                    param["execInst"] = "ParticipateDoNotInitiate";
                }
                else if (ReduceOnly && PostOnly)
                {
                    param["execInst"] = "ReduceOnly,ParticipateDoNotInitiate";
                }
                if (Hidden)
                {
                    param["displayQty"] = "0";
                }

                Json = BitmexJsonSerializer.Serialize(param);

                Content = new StringContent(Json, Encoding.UTF8, "application/json");
            }
        }
    }
}
