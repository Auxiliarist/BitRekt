using BitMexAPI.Rest;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitMexAPI.Client
{
    public class BitmexClient : IDisposable
    {
        public BitmexClient(BitmexWebsocketClient websocketClient, BitmexRestClient restClient)
        {
            WebsocketClient = websocketClient ?? throw new ArgumentNullException(nameof(websocketClient));
            RestClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
        }

        /// <summary> Provided message streams </summary>
        public BitmexStream Streams { get; } = new BitmexStream();

        public BitmexRestClient RestClient { get; }
        public BitmexWebsocketClient WebsocketClient { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
