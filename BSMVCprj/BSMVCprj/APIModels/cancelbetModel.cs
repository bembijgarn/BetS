using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BSMVCprj.APIModels
{
    public class cancelbetModel
    {
        [Required]
        public string token { get; set; }
        [Required]
        public long amount { get; set; }
        [Required]
        public string transactionId { get; set; }
        [Required]
        public int betTypeId { get; set; }
        [Required]
        public int gameId { get; set; }
        [Required]
        public int productId { get; set; }
        [Required]
        public int roundId { get; set; }
        [Required]
        public string hash { get; set; }
        [Required]
        public string currecny { get; set; }
        [Required]
        public string betTransactionId { get; set; }

    }
    public class cancelbetuserlist
    {
        public List<cancelbetModel> users;
        public cancelbetModel us1 = new cancelbetModel()
        {
            token = "L8aijgUY2185AIUJagUwiao9",
            amount = 50,
            transactionId = "218581251",
            betTypeId = new BetTypeId().Normal,
            gameId = 3,
            productId = 3,
            roundId = 15,
            hash = "ABC712571haugqg",
            currecny = "GEL",
            betTransactionId = "1951552"

        };
        public cancelbetModel us2 = new cancelbetModel()
        {
            token = "UUNGg18581251imvqivq",
            amount = 5,
            transactionId = "218581251",
            betTypeId = new BetTypeId().Tournamentbuyin,
            gameId = 6,
            productId = 6,
            roundId = 25,
            hash = "ABC712571haugqg",
            currecny = "USD",
            betTransactionId = "85912859125"

        };
        public cancelbetModel us3 = new cancelbetModel()
        {
            token = "28UsmafuqmwguqASF128SADF",
            amount = 100,
            transactionId = "218581251",
            betTypeId = new BetTypeId().Lockbalance,
            gameId = 10,
            productId = 10,
            roundId = 29,
            hash = "ABC712571haugqg",
            currecny = "RUB",
            betTransactionId = "219581251"

        };
        public cancelbetModel us4 = new cancelbetModel()
        {
            token = "Isuanv281481IKS92121",
            amount = 25,
            transactionId = "787258125",
            betTypeId = new BetTypeId().Freespin,
            gameId = 16,
            productId = 16,
            roundId = 45,
            hash = "ABC712571haugqg",
            currecny = "TYR",
            betTransactionId = "9358151"

        };
        public cancelbetModel us5 = new cancelbetModel()
        {
            token = "9Isamimg8128185WUAD",
            amount = 100,
            transactionId = "6531851",
            betTypeId = new BetTypeId().ReSpin,
            gameId = 13,
            productId = 13,
            roundId = 5,
            hash = "ABC712571haugqg",
            currecny = "EUR",
            betTransactionId = "217515915"

        };
        public cancelbetuserlist()
        {
            users = new List<cancelbetModel>();
            users.Add(us1);
            users.Add(us2);
            users.Add(us3);
            users.Add(us4);
            users.Add(us5);
        }
    }
}
