using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BitMexAPI.Requests.Rest
{
    public class InstrumentRequest : RestRequestBase
    {
        private bool active;
        private string symbol;

        public InstrumentRequest(bool active = false)
        {
            this.active = active;

            BuildParameters();
        }

        public InstrumentRequest(string symbol)
        {
            this.symbol = symbol;

            BuildParameters();
        }

        public override bool RequiresAuth => true;

        public override string Path => active ? "/api/v1/instrument/active" : "/api/v1/instrument";

        protected override HttpMethod MethodType => HttpMethod.Get;

        public override void BuildParameters()
        {
            base.BuildParameters();

            if(symbol != null)
            {
                Dictionary<string, string> param = new Dictionary<string, string>
                {
                    ["symbol"] = symbol,
                };

                //Json = BuildQueryData(param);
                //Json = "filter={\"symbol\":\"XBTUSD\"}";

                var data = BuildQueryData(param);

                RequestUri = new Uri(RequestUri + "?" + data, UriKind.Absolute);
             
                Log.Debug(RequestUri.ToString());
            }
        }
    }
}
