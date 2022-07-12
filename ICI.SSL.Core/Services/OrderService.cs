#nullable disable

using Microsoft.Extensions.Options;

namespace ICI.SSL.Core
{
    public class OrderService : ApiRequestBase, IOrderService
    {
        private readonly IOptions<ApiOptions> _options;

        public OrderService(IOptions<ApiOptions> options) : base(options)
        {
            _options = options;
        }

        public async Task<Order> CreateOrderAsync(Certificate certificate)
        {
            string uri = $"v1/ssl/order/subscription/{_options.Value.SubscriptionId}/create";

            Order newOrder = await PostAsync<Certificate, Order>(uri, certificate);

            return newOrder;
        }

        public async Task<Order> GetOrderAsync(Certificate certificate)
        {
            string uri = $"v1/ssl/order/subscription/{_options.Value.SubscriptionId}/get";

            Order newOrder = await PostAsync<Certificate, Order>(uri, certificate);

            return newOrder;
        }

        public async Task ValidateOrderAsync(Certificate certificate)
        {
            string uri = $"v1/ssl/order/subscription/{_options.Value.SubscriptionId}/validate";

            await PostAsync<Certificate>(uri, certificate);
        }

        public async Task FinalizeOrderAsync(Certificate certificate)
        {
            string uri = $"v1/ssl/order/subscription/{_options.Value.SubscriptionId}/finalize";

            await PostAsync<Certificate>(uri, certificate);
        }
    }
}
