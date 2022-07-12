namespace ICI.SSL.Core
{
    public interface ICsrInfoService
    {
        Task<CsrInfo> CreateOrUpdateCsrInfoAsync(CsrInfo csrInfo);
        Task<CsrInfo> GetCsrInfoBySubscriptionAsync();
        Task<CsrInfo> GetCsrInfoByIdAsync(int id);
        Task DeleteCsrInfoAsync(int id);
    }
}
