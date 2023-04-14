using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BSMVCprj.APIModels
{
    public class Authmodel
    {
        public string PublicToken { get; set; }
        [Required]
        public int MerchantId { get; set; }
        [Required]
        public string Lang { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public int IsFreeplay { get; set; }
        [Required]
        public string Platform { get; set; }
    }
    public class Authlistuser
    {
        public List<Authmodel> users;
        public Authmodel us1 = new Authmodel()
        {
            PublicToken = "L8aijgUY2185AIUJagUwiao9",
            MerchantId = 1,
            Lang = "GE",
            GameId = 10,
            ProductId = 10,
            IsFreeplay = 0,
            Platform = "Desktop"
        };
        public Authmodel us2 = new Authmodel()
        {
            PublicToken = "UUNGg18581251imvqivq",
            MerchantId = 2,
            Lang = "EN",
            GameId = 20,
            ProductId = 20,
            IsFreeplay = 1,
            Platform = "Desktop"
        };
        public Authmodel us3 = new Authmodel()
        {
            PublicToken = "28UsmafuqmwguqASF128SADF",
            MerchantId = 3,
            Lang = "DE",
            GameId = 15,
            ProductId = 15,
            IsFreeplay = 1,
            Platform = "Mobile"
        };
        public Authmodel us4 = new Authmodel()
        {
            PublicToken = "Isuanv281481IKS92121",
            MerchantId = 4,
            Lang = "RU",
            GameId = 21,
            ProductId = 21,
            IsFreeplay = 0,
            Platform = "Mobile"
        };
        public Authmodel us5 = new Authmodel()
        {
            PublicToken = "9Isamimg8128185WUAD",
            MerchantId = 5,
            Lang = "ES",
            GameId = 11,
            ProductId = 11,
            IsFreeplay = 1,
            Platform = "Desktop"
        };
        public Authlistuser()
        {
            users = new List<Authmodel>();
            users.Add(us1);
            users.Add(us2);
            users.Add(us3);
            users.Add(us4);
            users.Add(us5);
        }
    }
}
