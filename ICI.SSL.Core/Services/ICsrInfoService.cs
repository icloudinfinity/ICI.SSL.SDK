namespace ICI.SSL.Core
{
    public interface ICsrInfoService
    {
        Task<CsrInfo> CreateOrUpdateCsrInfoAsync(int subscriptionId, CsrInfo csrInfo);
        Task<CsrInfo> GetCsrInfoBySubscriptionAsync(int subscriptionId);
        Task<CsrInfo> GetCsrInfoByIdAsync(int subscriptionId, int id);
        Task DeleteCsrInfoAsync(int subscriptionId, int id);
    }
}
