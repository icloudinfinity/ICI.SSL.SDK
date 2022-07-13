#nullable disable

using Microsoft.Extensions.Options;

namespace ICI.SSL.Core
{
    public class CertificateService : ApiRequestBase, ICertificateService
    {
        public CertificateService(IOptions<ApiOptions> options) : base(options)
        {
        }

        public async Task<List<Certificate>> GetCertificatesInSubscriptionAsync(int subscriptionId)
        {
            string uri = $"v1/ssl/certificate/subscription/{subscriptionId}/getall";

            List<Certificate> certificates = await GetListResultAsync<Certificate>(uri);

            return certificates;
        }

        public async Task<Certificate> GetCertificateAsync(int subscriptionId,string certificateName)
        {
            string uri = $"v1/ssl/certificate/subscription/{subscriptionId}/certificateName/{certificateName}/get";

            Certificate certificate = await GetAsync<Certificate>(uri);

            return certificate;
        }

        public async Task<Certificate> GetCertificateGloballyAsync(int subscriptionId, string certificateName)
        {
            string uri = $"v1/ssl/certificate/subscription/{subscriptionId}/certificateName/{certificateName}/get/global";

            Certificate certificate = await GetAsync<Certificate>(uri);

            return certificate;
        }

        public async Task DeleteCertificateAsync(int subscriptionId, string certificateName)
        {
            string uri = $"v1/ssl/certificate/subscription/{subscriptionId}/certificateName/{certificateName}/delete";

            await DeleteAsync(uri);
        }
    }
}
