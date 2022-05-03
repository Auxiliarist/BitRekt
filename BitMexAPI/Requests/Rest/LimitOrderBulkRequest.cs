using BitMexAPI.Json;
using BitMexAPI.Responses.Orders;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BitMexAPI.Requests.Rest
{
    public class LimitOrderBulkRequest : RestRequestBase
    {
        private readonly Order[] Orders;

        public LimitOrderBulkRequest(Order[] orders)
        {
            Orders = orders;

            BuildParameters();
        }

        public override bool RequiresAuth => true;
        public override string Path => "/api/v1/order/bulk";
        protected override HttpMethod MethodType => HttpMethod.Post;

        public override void BuildParameters()
        {
            base.BuildParameters();

            Dictionary<string, Order[]> orders = new Dictionary<string, Order[]>();

            orders.Add("orders", Orders);

            Json = BitmexJsonSerializer.Serialize(orders);

            Content = new StringContent(Json, Encoding.UTF8, "application/json");
        }
    }
}
