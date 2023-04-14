using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace BSMVCprj.Models
{
    public class MoneyTransferM
    {
        [Required]
        [Display(Name = "User Email")]
        public string Email { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public Guid TransactionId { get; set; }
    }
}
