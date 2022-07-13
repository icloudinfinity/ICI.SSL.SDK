#nullable disable

using System.ComponentModel.DataAnnotations;

namespace ICI.SSL.Core
{
    public class CsrInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        [MaxLength(50)]
        public string countryName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        [MaxLength(50)]
        public string locality { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "State/Region")]
        [MaxLength(50)]
        public string state { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Organization")]
        [MaxLength(100)]
        public string organization { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Organization Unit")]
        [MaxLength(100)]
        public string organizationUnit { get; set; }

        [Required]
        [Display(Name = "Subscription Id")]
        public int subscriptionId { get; set; }
    }
}
