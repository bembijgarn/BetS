using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BSMVCprj.Models
{
    public class LoginM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public decimal Balance { get; set; }
    }
}
