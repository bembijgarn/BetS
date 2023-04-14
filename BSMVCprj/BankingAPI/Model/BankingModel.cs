using System;

namespace BankingAPI.Model
{
    public class BankingModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime Datetime { get; set; }
        public decimal Amount { get; set; }
        public decimal Bankcard { get; set; }
        public string Cardholder { get; set; }
    }
}
