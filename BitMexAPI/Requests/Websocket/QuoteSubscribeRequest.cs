﻿using BitMexAPI.Validations;

namespace BitMexAPI.Requests.Websocket
{
    public class QuoteSubscribeRequest : SubscribeRequestBase
    {
        /// <summary> Subscribe to quote (top level of the book) from all pairs </summary>
        public QuoteSubscribeRequest()
        {
            Symbol = string.Empty;
        }

        /// <summary> 
        ///    Subscribe to quote (top level of the book) from selected pair ('XBTUSD', etc)
        /// </summary>
        public QuoteSubscribeRequest(string pair)
        {
            BitmexValidation.ValidateInput(pair, nameof(pair));

            Symbol = pair;
        }

        public override string Topic => "quote";
        public override string Symbol { get; }
    }
}