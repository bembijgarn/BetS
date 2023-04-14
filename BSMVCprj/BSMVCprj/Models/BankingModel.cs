using System;

namespace BSMVCprj.Models
{
    public class BankingModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Datetime { get; set; }
        public decimal Amount { get; set; }
        public decimal Bankcard { get; set; }
        public string Cardholder { get; set; }
        public Guid TransactionId { get; set; }

    }
}
