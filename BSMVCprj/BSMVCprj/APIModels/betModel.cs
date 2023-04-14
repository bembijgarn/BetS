using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BSMVCprj.APIModels
{
    public class betModel
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
        public int campaignId { get; set; }
        public string campaignName { get; set; }
    }
    public class BetTypeId
    {
        public int Normal = 1;
        public int Freespin = 2;
        public int ReSpin = 3;
        public int Lockbalance = 16;
        public int Tournamentbuyin = 18;
        public int Drop = 46;
        public int Bonus = 7;
    }
    public class betuserlist
    {
        public List<betModel> lasa;
        public betModel us1 = new betModel()
        {
            token = "L8aijgUY2185AIUJagUwiao9",
            amount = 10,
            transactionId = "21851825",
            betTypeId = new BetTypeId().Normal,
            gameId = 2,
            productId = 2,
            roundId = 71,
            hash = "SHA256",
            currecny = "GEL",
            campaignId = 20,
            campaignName = "blabla"
        };
        public betModel us2 = new betModel()
        {
            token = "UUNGg18581251imvqivq",
            amount = 2,
            transactionId = "1850192",
            betTypeId = new BetTypeId().Drop,
            gameId = 7,
            productId = 7,
            roundId = 117,
            hash = "SHA256",
            currecny = "USD",
            campaignId = 12,
            campaignName = "akjg"
        };
        public betModel us3 = new betModel()
        {
            token = "28UsmafuqmwguqASF128SADF",
            amount = 50,
            transactionId = "9126961",
            betTypeId = new BetTypeId().Tournamentbuyin,
            gameId = 19,
            productId = 19,
            roundId = 12,
            hash = "SHA256",
            currecny = "EUR",
            campaignId = 99,
            campaignName = "sadqwq"
        };
        public betModel us4 = new betModel()
        {
            token = "Isuanv281481IKS92121",
            amount = 100,
            transactionId = "3761561",
            betTypeId = new BetTypeId().Freespin,
            gameId = 33,
            productId = 33,
            roundId = 47,
            hash = "SHA256",
            currecny = "RUB",
            campaignId = 87,
            campaignName = "laskfq"
        };
        public betModel us5 = new betModel()
        {
            token = "9Isamimg8128185WUAD",
            amount = 30,
            transactionId = "57579151",
            betTypeId = new BetTypeId().Bonus,
            gameId = 10,
            productId = 10,
            roundId = 100,
            hash = "SHA256",
            currecny = "TRY",
            campaignId = 20,
            campaignName = "blabla"
        };
        public betuserlist()
        {
            lasa = new List<betModel>();
            lasa.Add(us1);
            lasa.Add(us2);
            lasa.Add(us3);
            lasa.Add(us4);
            lasa.Add(us5);
        }
    }
}
