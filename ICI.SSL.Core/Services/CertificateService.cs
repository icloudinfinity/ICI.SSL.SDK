#nullable disable

using Microsoft.Extensions.Options;

namespace ICI.SSL.Core
{
    public class CertificateService : ApiRequestBase, ICertificateService
    {
        private readonly IOptions<ApiOptions> _options;

        public CertificateService(IOptions<ApiOptions> options) : base(options)
        {
            _options = options;
        }

        public async Task<List<Certificate>> GetCertificatesInSubscriptionAsync()
        {
            string uri = $"v1/ssl/certificate/subscription/{_options.Value.SubscriptionId}/getall";

            List<Certificate> certificates = await GetListResultAsync<Certificate>(uri);

            return certificates;
        }

        public async Task<Certificate> GetCertificateAsync(string certificateName)
        {
            string uri = $"v1/ssl/certificate/subscription/{_options.Value.SubscriptionId}/certificateName/{certificateName}/get";

            Certificate certificate = await GetAsync<Certificate>(uri);

            return certificate;
        }

        public async Task<Certificate> GetCertificateGloballyAsync(string certificateName)
        {
            string uri = $"v1/ssl/certificate/subscription/{_options.Value.SubscriptionId}/certificateName/{certificateName}/get/global";

            Certificate certificate = await GetAsync<Certificate>(uri);

            return certificate;
        }

        public async Task DeleteCertificateAsync(string certificateName)
        {
            string uri = $"v1/ssl/certificate/subscription/{_options.Value.SubscriptionId}/certificateName/{certificateName}/delete";

            await DeleteAsync(uri);
        }
    }
}
