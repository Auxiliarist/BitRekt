namespace BitMexAPI.Requests.Websocket
{
    public class WalletSubscribeRequest : SubscribeRequestBase
    {
        public override string Topic => "wallet";
    }
}