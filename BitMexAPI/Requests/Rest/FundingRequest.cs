using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BitMexAPI.Requests.Rest
{
    public class FundingRequest : RestRequestBase
    {
        public FundingRequest()
        {
        }

        public override bool RequiresAuth => throw new NotImplementedException();

        public override string Path => throw new NotImplementedException();

        protected override HttpMethod MethodType => throw new NotImplementedException();

        public override void BuildParameters()
        {
            throw new NotImplementedException();
        }
    }
}