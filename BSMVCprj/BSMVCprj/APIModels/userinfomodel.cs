using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Threading;

namespace BSMVCprj.APIModels
{
    public class userinfomodel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public int Gender { get; set; }
        public string Currecy { get; set; }
        public long CurrentBalance { get; set; }
    }
    public class userlist
    {
        public List<userinfomodel> users;
        public userinfomodel us1 = new userinfomodel() {
            UserId = "1",
            UserName = "fiqjwkfgq",
            FirstName = "duta",
            LastName = "skhirtladze",
            Email = "afsef@eafsef.com",
            CountryCode = "GE",
            CountryName = "Georgia",
            Gender = 1,
            Currecy = "GEL",
            CurrentBalance = 15000
        };
        public userinfomodel us2 = new userinfomodel()
        {
            UserId = "2",
            UserName = "bemb",
            FirstName = "miroslav",
            LastName = "klose",
            Email = "afsef@eafsef.com",
            CountryCode = "DE",
            CountryName = "Germany",
            Gender = 1,
            Currecy = "EU",
            CurrentBalance = 23232
        };
        public userinfomodel us3 = new userinfomodel()
        {
            UserId = "3",
            UserName = "mcckgren",
            FirstName = "nency",
            LastName = "jordan",
            Email = "asgagagq@eafsef.com",
            CountryCode = "USA",
            CountryName = "UnitedStates",
            Gender = 2,
            Currecy = "USD",
            CurrentBalance = 23232
        };
        public userinfomodel us4 = new userinfomodel()
        {
            UserId = "4",
            UserName = "natsiusha",
            FirstName = "natasha",
            LastName = "dushkina",
            Email = "mrrr@eafsef.com",
            CountryCode = "RU",
            CountryName = "Russia",
            Gender = 2,
            Currecy = "RUB",
            CurrentBalance = 9400
        };
        public userinfomodel us5 = new userinfomodel()
        {
            UserId = "5",
            UserName = "mohaaamad",
            FirstName = "agqgq",
            LastName = "gqqgqg",
            Email = "asgagagq@eafsef.com",
            CountryCode = "TUR",
            CountryName = "Turkey",
            Gender = 1,
            Currecy = "TRY",
            CurrentBalance = 23232
        };
        public userinfomodel us6 = new userinfomodel()
        {
            UserId = "6",
            UserName = "anabell3",
            FirstName = "ana",
            LastName = "gqqgqg",
            Email = "asgagagq@eafsef.com",
            CountryCode = "GEO",
            CountryName = "Georgia",
            Gender = 2,
            Currecy = "GEL",
            CurrentBalance = 23232
        };
        public userlist()
        {
            users = new List<userinfomodel>();
            users.Add(us1);
            users.Add(us2);
            users.Add(us3);
            users.Add(us4);
            users.Add(us5);
            users.Add(us6);
        }
       
    }
}
