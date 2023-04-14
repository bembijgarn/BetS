using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BSMVCprj.Models
{
    public class RegistrationM
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Identityid")]
        public double IdentityId { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public decimal Balance { get; set; }
        [Required]
        [Display(Name = "BankCard")]
        public double BankCard { get; set; }
    }
}
