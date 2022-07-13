#nullable disable

using Microsoft.Extensions.Options;

namespace ICI.SSL.Core
{
    public class OrderService : ApiRequestBase, IOrderService
    {
        public OrderService(IOptions<ApiOptions> options) : base(options)
        {
        }

        public async Task<Order> CreateOrderAsync(int subscriptionId, Certificate certificate)
        {
            string uri = $"v1/ssl/order/subscription/{subscriptionId}/create";

            Order newOrder = await PostAsync<Certificate, Order>(uri, certificate);

            return newOrder;
        }

        public async Task<Order> GetOrderAsync(int subscriptionId, Certificate certificate)
        {
            string uri = $"v1/ssl/order/subscription/{subscriptionId}/get";

            Order newOrder = await PostAsync<Certificate, Order>(uri, certificate);

            return newOrder;
        }

        public async Task ValidateOrderAsync(int subscriptionId, Certificate certificate)
        {
            string uri = $"v1/ssl/order/subscription/{subscriptionId}/validate";

            await PostAsync<Certificate>(uri, certificate);
        }

        public async Task FinalizeOrderAsync(int subscriptionId, Certificate certificate)
        {
            string uri = $"v1/ssl/order/subscription/{subscriptionId}/finalize";

            await PostAsync<Certificate>(uri, certificate);
        }
    }
}
