namespace BitMexAPI.Requests.Websocket
{
    public class PositionSubscribeRequest : SubscribeRequestBase
    {
        public override string Topic => "position";
    }
}