using Microsoft.Extensions.Options;

namespace ICI.SSL.Core
{
    public class CsrInfoService : ApiRequestBase, ICsrInfoService
    {
        private readonly IOptions<ApiOptions> _options;

        public CsrInfoService(IOptions<ApiOptions> options) : base(options)
        {
            _options = options;
        }

        public async Task<CsrInfo> CreateOrUpdateCsrInfoAsync(CsrInfo csrInfo)
        {
            string uri = $"v1/ssl/csrinfo/subscription/{_options.Value.SubscriptionId}/createorupdate";

            CsrInfo newCsrInfo = await PutAsync<CsrInfo, CsrInfo>(uri, csrInfo);

            return newCsrInfo;
        }

        public async Task<CsrInfo> GetCsrInfoBySubscriptionAsync()
        {
            string uri = $"v1/ssl/csrinfo/subscription/{_options.Value.SubscriptionId}";

            CsrInfo csrInfo = await GetAsync<CsrInfo>(uri);

            return csrInfo;
        }

        public async Task<CsrInfo> GetCsrInfoByIdAsync(int id)
        {
            string uri = $"v1/ssl/csrinfo/subscription/{_options.Value.SubscriptionId}/id/{id}";

            CsrInfo csrInfo = await GetAsync<CsrInfo>(uri);

            return csrInfo;
        }

        public async Task DeleteCsrInfoAsync(int id)
        {
            string uri = $"v1/ssl/csrinfo/subscription/{_options.Value.SubscriptionId}/id/{id}";

            await DeleteAsync(uri);
        }
    }
}
