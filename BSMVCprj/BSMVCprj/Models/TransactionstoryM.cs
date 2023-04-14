using System;

namespace BSMVCprj.Models
{
    public class TransactionstoryM
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime Datetime { get; set; }
        public int userId { get; set; }
    }
}
