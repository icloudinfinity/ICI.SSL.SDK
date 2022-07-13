#nullable disable

using System.ComponentModel.DataAnnotations;

namespace ICI.SSL.Core
{
    public class CsrInfo
    {
        public int Id { get; set; }
        public string countryName { get; set; }
        public string locality { get; set; }
        public string state { get; set; }
        public string organization { get; set; }
        public string organizationUnit { get; set; }
        public int subscriptionId { get; set; }
    }
}
