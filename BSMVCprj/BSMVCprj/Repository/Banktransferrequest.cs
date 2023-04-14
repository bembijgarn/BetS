using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BSMVCprj.Repository
{
    public class Banktransferrequest : IBanktransferrequest
    {
        private readonly IConfiguration _config;
        public Banktransferrequest(IConfiguration config)
        {
            _config = config;
        }
        public int Deposit(MoneyTransferM transfer)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "deporeq";
            var parameters = new DynamicParameters();
            parameters.Add("amount", transfer.Amount);
            parameters.Add("transactionid", transfer.TransactionId);
            parameters.Add("status", transfer.Status);
            var depo = connection.Execute(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (depo < 0)
            {
                return depo;
            }
            return 1;
        }

        public int Withdraw(MoneyTransferM transfer)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "withreq";
            var parameters = new DynamicParameters();
            parameters.Add("amount", transfer.Amount);
            parameters.Add("transactionid", transfer.TransactionId);
            parameters.Add("status", transfer.Status);
            var depo = connection.Execute(procedurename,parameters,commandType:System.Data.CommandType.StoredProcedure);
            if (depo < 0)
            {
                return depo;
            }
            return 1;
        }
    }
}
