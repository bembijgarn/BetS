using System;

namespace BankPayment.Models
{
    public class PaymentModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }

    }
}
