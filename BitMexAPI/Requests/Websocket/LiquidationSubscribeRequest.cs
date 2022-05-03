namespace BitMexAPI.Requests.Websocket
{
    public class LiquidationSubscribeRequest : SubscribeRequestBase
    {
        public override string Topic => "liquidation";
    }
}