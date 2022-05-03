namespace BitMexAPI.Requests.Websocket
{
    public class OrderSubscribeRequest : SubscribeRequestBase
    {
        public override string Topic => "order";
    }
}