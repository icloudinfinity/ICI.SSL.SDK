namespace ICI.SSL.Core.Test
{
    [TestClass]
    public class CertificateServiceTest
    {
        private readonly ICertificateService _certificateService;
        private const int subscriptionId = 1;

        public CertificateServiceTest()
        {
            _certificateService = (ICertificateService)DependencyResolver.ServiceProvider().GetService(typeof(ICertificateService));
        }

        [TestMethod]
        public async Task GetCertificatesInSubscriptionTest()
        {
            try
            {
                List<Certificate> certificates = await _certificateService.GetCertificatesInSubscriptionAsync(subscriptionId);
                Assert.AreNotEqual(0, certificates?.Count);
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetCertificateTest()
        {
            string certificateName = "shopeneur.com";

            try
            {
                Certificate certificate = await _certificateService.GetCertificateAsync(subscriptionId, certificateName);
                Assert.AreEqual(certificateName, certificate?.certificateName ?? string.Empty);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetCertificateGloballyTest()
        {
            string certificateName = "shopeneur.com";

            try
            {
                Certificate certificate = await _certificateService.GetCertificateGloballyAsync(subscriptionId, certificateName);
                Assert.AreEqual(certificateName, certificate?.certificateName ?? string.Empty);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task DeleteCertificateTest()
        {
            string certificateName = "shopeneur.com";

            try
            {
                await _certificateService.DeleteCertificateAsync(subscriptionId, certificateName);
                Assert.AreEqual(1,1);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }
    }
}
