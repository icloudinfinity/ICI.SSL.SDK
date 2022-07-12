namespace ICI.SSL.Core.Test
{
    [TestClass]
    public class OrderServiceTest
    {
        private readonly IOrderService _orderService;

        public OrderServiceTest()
        {
            _orderService = (IOrderService)DependencyResolver.ServiceProvider().GetService(typeof(IOrderService));
        }

        [TestMethod]
        public async Task CreateOrderTest()
        {
            Certificate certificate = new Certificate
            {
                certificateName = "shopeneur.com",
                isSAN = false,
                rootDomain = "shopeneur.com",
                email = "support@shopeneur.com",
                challengeType = "dns"
            };

            try
            {
                Order order = await _orderService.CreateOrderAsync(certificate);
                Assert.AreNotEqual(String.Empty, order?.orderUri ?? String.Empty);
            }
            catch(Exception ex)
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
                rootDomain = "shopeneur.com",
                challengeType = "dns"
            };

            try
            {
                Order order = await _orderService.GetOrderAsync(certificate);
                Assert.AreEqual(orderuri,order?.orderUri ?? string.Empty);
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
                await _orderService.ValidateOrderAsync(certificate);
                Assert.AreEqual(1,1);
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
                certificateName = "shopeneur.com",
                isSAN = false,
                rootDomain = "shopeneur.com",
                email = "support@shopeneur.com",
                password = "pwd1234",
                orderUri = "https://acme-staging-v02.api.letsencrypt.org/acme/order/60431204/3156601004",
                challengeType = "dns"
            };

            try
            {
                await _orderService.FinalizeOrderAsync(certificate);
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
