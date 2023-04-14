using System;
using System.ComponentModel.DataAnnotations;

namespace BankingMVC.Models
{
    public class Bankingmodel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Datetime { get; set; }
        public decimal Amount { get; set; }
        [Required]
        public decimal Bankcard { get; set; }
        [Required]
        public string Cardholder { get; set; }
        public int userid { get; set; }
        public Guid TransactionId { get; set; }
    }
}
