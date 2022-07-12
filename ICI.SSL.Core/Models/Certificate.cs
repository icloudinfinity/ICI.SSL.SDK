#nullable disable

namespace ICI.SSL.Core
{
    public class Certificate
    {
        public string certificateName { get; set; }
        public bool isSAN { get; set; }
        public string rootDomain { get; set; }
        public string email { get; set; }
        public string challengeType { get; set; }
        public string orderUri { get; set; }
        public CsrInfo csrInfo { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime expiryDate { get; set; }
        public int id { get; set; }
        public int subscriptionId { get; set; }
        public string password { get; set; }
        public string pfxString { get; set; }
        public CertificateDownloadUrl certificateDownloadUrl { get; set; }
    }

    public class CertificateDownloadUrl
    {
        public string pemUrl { get; set; }
        public string pfxUrl { get; set; }
        public string pfxTxtUrl { get; set; }
        public string cerUrl { get; set; }
        public string crtUrl { get; set; }
        public string txtUrl { get; set; }

        public string keyUrl { get; set; }
        public string certCrtUrl { get; set; }
        public string cabundleCrtUrl { get; set; }
        public string fullchainCrtUrl { get; set; }
    }
}
