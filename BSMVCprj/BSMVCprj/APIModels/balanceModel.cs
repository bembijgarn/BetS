using System.Collections.Generic;

namespace BSMVCprj.APIModels
{
    public class balanceModel
    {
        public  string Token { get; set; }
        public long Amount { get;set; }
        public int GameId { get; set; }
        public int ProductId { get; set; }
        public string Hash { get; set; }
        public string Currency { get; set; }
    }
    public class balanceuserlist
    {
        public List<balanceModel> users;
        balanceModel us1 = new balanceModel()
        {
            Token = "L8aijgUY2185AIUJagUwiao9",
            Amount = 370,
            GameId = 10,
            ProductId = 10,
            Hash = "AUS151iajkgiAUIS15",
            Currency = "GEL"
        };
        balanceModel us2 = new balanceModel()
        {
            Token = "UUNGg18581251imvqivq",
            Amount = 400,
            GameId = 13,
            ProductId = 13,
            Hash = "AUS151iajkgiAUIS15",
            Currency = "USD"
        };
        balanceModel us3 = new balanceModel()
        {
            Token = "28UsmafuqmwguqASF128SADF",
            Amount = 1000,
            GameId = 1,
            ProductId = 1,
            Hash = "AUS151iajkgiAUIS15",
            Currency = "TYR"
        };
        balanceModel us4 = new balanceModel()
        {
            Token = "Isuanv281481IKS92121",
            Amount = 100,
            GameId = 34,
            ProductId = 34,
            Hash = "AUS151iajkgiAUIS15",
            Currency = "EUR"
        };
        balanceModel us5 = new balanceModel()
        {
            Token = "9Isamimg8128185WUAD",
            Amount = 2000,
            GameId = 19,
            ProductId = 19,
            Hash = "AUS151iajkgiAUIS15",
            Currency = "RUB"
        };
        public balanceuserlist()
        {
            users = new List<balanceModel>();
            users.Add(us1);
            users.Add(us2);
            users.Add(us3);
            users.Add(us4);
            users.Add(us5);
        }
    }
}
