using System;

namespace BSMVCprj.Models
{
    public class TokenModel
    {
        public Guid? TokenId { get; set; }
        public int? TransactionId { get; set; }
        public decimal? CurrentBalance { get; set; }
        public int? Check { get; set; }
    }
}
