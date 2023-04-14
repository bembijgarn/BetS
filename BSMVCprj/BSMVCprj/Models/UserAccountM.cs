namespace BSMVCprj.Models
{
    public class UserAccountM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public double IdentityId { get; set; }
        public string Username { get; set; }
        public decimal Balance { get; set; }
        public double BankCard { get; set; }
        public string CountryCode { get; set; } = "GEO";
        public string CountryName { get; set; } = "Georgia";
        public int Gender { get; set; } = 2;
        public string Currecy { get; set; } = "GEL";
    }
}
