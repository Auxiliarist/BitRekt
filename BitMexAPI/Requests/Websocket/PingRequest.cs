using BitMexAPI.Messages;

namespace BitMexAPI.Requests.Websocket
{
    public class PingRequest : RequestBase
    {
        public override MessageType Operation => MessageType.Ping;

        public override bool IsRaw => true;
    }
}