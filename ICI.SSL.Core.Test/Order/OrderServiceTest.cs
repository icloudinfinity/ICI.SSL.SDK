namespace ICI.SSL.Core.Test
{
    [TestClass]
    public class OrderServiceTest
    {
        private readonly IOrderService _orderService;
        private const int subscriptionId = 1;

        public OrderServiceTest()
        {
            _orderService = (IOrderService)DependencyResolver.ServiceProvider().GetService(typeof(IOrderService));
        }

        [TestMethod]
        public async Task CreateOrderTest()
        {
            Certificate certificate = new Certificate
            {
                certificateName = "contoso.com",
                isSAN = false,
                rootDomain = "contoso.com",
                email = "support@mail.com",
                challengeType = "dns"
            };

            try
            {
                Order order = await _orderService.CreateOrderAsync(subscriptionId, certificate);
                Assert.AreNotEqual(String.Empty, order?.orderUri ?? String.Empty);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetOrderTest()
        {
            string orderuri = "https://acme-staging-v02.api.letsencrypt.org/acme/order/60431204/3156601004";

            Certificate certificate = new Certificate
            {
                orderUri = orderuri,
                rootDomain = "contoso.com",
                challengeType = "dns"
            };

            try
            {
                Order order = await _orderService.GetOrderAsync(subscriptionId, certificate);
                Assert.AreEqual(orderuri, order?.orderUri ?? string.Empty);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task ValidateOrderTest()
        {
            Certificate certificate = new Certificate
            {
                orderUri = "https://acme-staging-v02.api.letsencrypt.org/acme/order/60431204/3156601004",
                challengeType = "dns"
            };

            try
            {
                await _orderService.ValidateOrderAsync(subscriptionId, certificate);
                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task FinalizeOrderTest()
        {
            Certificate certificate = new Certificate
            {
                certificateName = "contoso.com",
                isSAN = false,
                rootDomain = "contoso.com",
                email = "support@mail.com",
                password = "pwd1234",
                orderUri = "https://acme-staging-v02.api.letsencrypt.org/acme/order/60431204/3156601004",
                challengeType = "dns"
            };

            try
            {
                await _orderService.FinalizeOrderAsync(subscriptionId, certificate);
                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }
    }
}
