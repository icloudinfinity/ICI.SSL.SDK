using Microsoft.Extensions.Options;

namespace ICI.SSL.Core
{
    public class CsrInfoService : ApiRequestBase, ICsrInfoService
    {
        public CsrInfoService(IOptions<ApiOptions> options) : base(options)
        {
        }

        public async Task<CsrInfo> CreateOrUpdateCsrInfoAsync(int subscriptionId, CsrInfo csrInfo)
        {
            string uri = $"v1/ssl/csrinfo/subscription/{subscriptionId}/createorupdate";

            CsrInfo newCsrInfo = await PutAsync<CsrInfo, CsrInfo>(uri, csrInfo);

            return newCsrInfo;
        }

        public async Task<CsrInfo> GetCsrInfoBySubscriptionAsync(int subscriptionId)
        {
            string uri = $"v1/ssl/csrinfo/subscription/{subscriptionId}";

            CsrInfo csrInfo = await GetAsync<CsrInfo>(uri);

            return csrInfo;
        }

        public async Task<CsrInfo> GetCsrInfoByIdAsync(int subscriptionId, int id)
        {
            string uri = $"v1/ssl/csrinfo/subscription/{subscriptionId}/id/{id}";

            CsrInfo csrInfo = await GetAsync<CsrInfo>(uri);

            return csrInfo;
        }

        public async Task DeleteCsrInfoAsync(int subscriptionId, int id)
        {
            string uri = $"v1/ssl/csrinfo/subscription/{subscriptionId}/id/{id}";

            await DeleteAsync(uri);
        }
    }
}
