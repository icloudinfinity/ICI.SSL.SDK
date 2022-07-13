namespace ICI.SSL.Core
{
    public interface ICertificateService
    {
        Task<List<Certificate>> GetCertificatesInSubscriptionAsync(int subscriptionId);
        Task<Certificate> GetCertificateAsync(int subscriptionId, string certificateName);
        Task<Certificate> GetCertificateGloballyAsync(int subscriptionId, string certificateName);
        Task DeleteCertificateAsync(int subscriptionId, string certificateName);
    }
}
