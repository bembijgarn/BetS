using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BSMVCprj.APIModels
{
    public class changewinModel
    {
        [Required]
        public string token { get; set; }
        [Required]
        public long amount { get; set; }
        [Required]
        public long previousAmount { get; set; }
        [Required]
        public string transactionId { get; set; }
        [Required]
        public string previousTransactionId { get; set; }
        [Required]
        public int changewinTypeId { get; set; }
        [Required]
        public int gameId { get; set; }
        [Required]
        public int productId { get; set; }
        [Required]
        public int roundId { get; set; }
        [Required]
        public string hash { get; set; }
        [Required]
        public string currency { get; set; }
    }
    public class ChangeWinTypeId
    {
        public int Open = 101;
        public int Returned = 102;
        public int Lost = 103;
        public int Won = 104;
        public int Cashout = 105;
    }
    public class changewinuserlist
    {
        public List<changewinModel> users;
        changewinModel us1 = new changewinModel()
        {
            token = "8Uwqimgqigmqgqgqg",
            amount = 200,
            previousAmount = 100,
            transactionId = "218581515",
            previousTransactionId = "21651295915",
            changewinTypeId = new ChangeWinTypeId().Open,
            gameId = 5,
            productId = 5,
            roundId = 10,
            hash = "Uznun15715SYA",
            currency = "GEL"
        };
        changewinModel us2 = new changewinModel()
        {
            token = "P215915ISAUG18515",
            amount = 300,
            previousAmount = 280,
            transactionId = "81959151",
            previousTransactionId = "8018515",
            changewinTypeId = new ChangeWinTypeId().Returned,
            gameId = 19,
            productId = 19,
            roundId = 45,
            hash = "Uznun15715SYA",
            currency = "TRY"
        };
        changewinModel us3 = new changewinModel()
        {
            token = "Zuuwm18185U8s81USv",
            amount = 1000,
            previousAmount = 800,
            transactionId = "218581515",
            previousTransactionId = "21651295915",
            changewinTypeId = new ChangeWinTypeId().Won,
            gameId = 21,
            productId = 21,
            roundId = 31,
            hash = "Uznun15715SYA",
            currency = "EUR"
        };
        changewinModel us4 = new changewinModel()
        {
            token = "8Uwqimgqigmqgqgqg",
            amount = 100,
            previousAmount = 50,
            transactionId = "55959153",
            previousTransactionId = "558912591",
            changewinTypeId = new ChangeWinTypeId().Cashout,
            gameId = 7,
            productId = 7,
            roundId = 11,
            hash = "Uznun15715SYA",
            currency = "USD"
        };
        changewinModel us5 = new changewinModel()
        {
            token = "Uztm218581aijsgijg",
            amount = 600,
            previousAmount = 500,
            transactionId = "81905125",
            previousTransactionId = "8019251",
            changewinTypeId = new ChangeWinTypeId().Lost,
            gameId = 9,
            productId = 9,
            roundId = 15,
            hash = "Uznun15715SYA",
            currency = "RUB"
        };
        public changewinuserlist()
        {
            users = new List<changewinModel>();
            users.Add(us1);
            users.Add(us2);
            users.Add(us3);
            users.Add(us4);
            users.Add(us5);
        }
    }
}
