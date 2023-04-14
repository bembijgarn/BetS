using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BSMVCprj.APIModels
{
    public class winModel
    {
        [Required]
        public string token { get; set; }
        [Required]
        public long amount { get; set; }
        [Required]
        public string transactionId { get; set; }
        [Required]
        public int winTypeId { get; set; }
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
    public class WinTypeId
    {
        public int Normal = 1;
        public int FreeSpin = 2;
        public int ReSpin = 3;
        public int Unlockbalance = 17;
        public int CancelTournamentbuyin = 19;
        public int Tournamentwin = 20;
        public int Tournamentbountly = 21;
        public int Achievementclaim = 26;
        public int Cancelbet = 41;
        public int jackpot = 44;
        public int Drop = 47;
        public int Bonus = 7;

    }
    public class winuserlist
    {
        public List<winModel> users;
        public winModel us1 = new winModel()
        {
            token = "L8aijgUY2185AIUJagUwiao9",
            amount = 10,
            transactionId = "2815812921",
            winTypeId = new WinTypeId().Bonus,
            gameId = 13,
            productId = 13,
            roundId = 27,
            hash = "wikagjiqjgqijqijgf8211qkfg",
            currecny = "USD",
            campaignId = 36,
            campaignName = "asighjqaigq"
        };
        public winModel us2 = new winModel()
        {
            token = "UUNGg18581251imvqivq",
            amount = 5,
            transactionId = "93151835",
            winTypeId = new WinTypeId().jackpot,
            gameId = 1,
            productId = 1,
            roundId = 7,
            hash = "wikagjiqjgqijqijgf8211qkfg",
            currecny = "GEL",
            campaignId = 16,
            campaignName = "mypwopqk"
        };
        public winModel us3 = new winModel()
        {
            token = "28UsmafuqmwguqASF128SADF",
            amount = 20,
            transactionId = "7165125192",
            winTypeId = new WinTypeId().Tournamentbountly,
            gameId = 29,
            productId = 29,
            roundId = 16,
            hash = "wikagjiqjgqijqijgf8211qkfg",
            currecny = "EUR",
            campaignId = 47,
            campaignName = "bastuubuj"
        };
        public winModel us4 = new winModel()
        {
            token = "Isuanv281481IKS92121",
            amount = 100,
            transactionId = "1825812591",
            winTypeId = new WinTypeId().Cancelbet,
            gameId = 4,
            productId = 4,
            roundId = 1,
            hash = "wikagjiqjgqijqijgf8211qkfg",
            currecny = "TRY",
            campaignId = 78,
            campaignName = "betmosl"
        };
        public winModel us5 = new winModel()
        {
            token = "9Isamimg8128185WUAD",
            amount = 3000,
            transactionId = "48719351",
            winTypeId = new WinTypeId().Tournamentwin,
            gameId = 30,
            productId = 30,
            roundId = 50,
            hash = "wikagjiqjgqijqijgf8211qkfg",
            currecny = "GBP",
            campaignId = 90,
            campaignName = "ukqiokgiq"
        };
        public winuserlist()
        {
            users = new List<winModel>();
            users.Add(us1);
            users.Add(us2);
            users.Add(us3);
            users.Add(us4);
            users.Add(us5);
        }
    }
}
