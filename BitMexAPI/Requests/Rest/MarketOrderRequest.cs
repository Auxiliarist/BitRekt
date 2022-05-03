using System.Net.Http;

namespace BitMexAPI.Requests.Rest
{
    public class MarketOrderRequest : RestRequestBase
    {
        public MarketOrderRequest()
        {
        }

        public override bool RequiresAuth => throw new System.NotImplementedException();

        public override string Path => throw new System.NotImplementedException();

        protected override HttpMethod MethodType => throw new System.NotImplementedException();

        public override void BuildParameters()
        {
            throw new System.NotImplementedException();
        }
    }
}