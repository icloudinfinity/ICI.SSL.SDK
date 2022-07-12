namespace ICI.SSL.Core
{
    public interface ICertificateService
    {
        Task<List<Certificate>> GetCertificatesInSubscriptionAsync();
        Task<Certificate> GetCertificateAsync(string certificateName);
        Task<Certificate> GetCertificateGloballyAsync(string certificateName);
        Task DeleteCertificateAsync(string certificateName);
    }
}
