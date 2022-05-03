using BitMexAPI.Validations;
using System.Runtime.Serialization;

namespace BitMexAPI.Requests.Websocket
{
    public class InstrumentSubscribeRequest : SubscribeRequestBase
    {
        /// <summary> 
        ///    Subscribe to instrument updates including turnover and bid/ask from all pairs
        /// </summary>
        public InstrumentSubscribeRequest()
        {
            Symbol = string.Empty;
        }

        /// <summary> 
        ///    Subscribe toinstrument updates including turnover and bid/ask from selected pair
        ///    ('XBTUSD', etc)
        /// </summary>
        public InstrumentSubscribeRequest(string pair)
        {
            BitmexValidation.ValidateInput(pair, nameof(pair));

            Symbol = pair;
        }

        [IgnoreDataMember]
        public override string Topic => "instrument";
        [IgnoreDataMember]
        public override string Symbol { get; }
    }
}