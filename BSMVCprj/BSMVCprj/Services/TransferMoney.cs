using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BSMVCprj.Services
{
    public class TransferMoney : IMoneyTransfer
    {
        private readonly IConfiguration _config;
        public TransferMoney(IConfiguration config)
        {
            _config = config;
        }

        public int Deposit(BankingModel transfer)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "deposit";
            var parameters = new DynamicParameters();
            parameters.Add("amount", transfer.Amount);
            parameters.Add("TransactionId", transfer.TransactionId);
            var depo = connection.Execute(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (depo < 0)
            {
                return depo;
            }
            return 1;
        }

        public int MoneyTransfer(MoneyTransferM transfer, int userid)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "starttran";
            var parameters = new DynamicParameters();
            parameters.Add("firstuserid", userid);
            parameters.Add("seconduseremail", transfer.Email);
            parameters.Add("amount", transfer.Amount);
            var dbuser = connection.Execute(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (dbuser < 0)
            {
                return dbuser;
            }
            return 1;
        }

        public int Withdraw(MoneyTransferM transfer, int Userid)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "withdraw";
            var parameters = new DynamicParameters();
            parameters.Add("amount", transfer.Amount);
            parameters.Add("userid", Userid);
            var withdraw = connection.Execute(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (withdraw < 0)
            {
                return withdraw;
            }
            return 1;
        }
    }
}
