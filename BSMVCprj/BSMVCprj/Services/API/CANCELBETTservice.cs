using BSMVCprj.Models;
using BSMVCprj.Repository.API;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BSMVCprj.Services.API
{
    public class CANCELBETTservice : ICANCELBETT
    {
        private readonly IConfiguration _config;
        public CANCELBETTservice(IConfiguration config)
        {
            _config = config;
        }
        public  void CancelBett(string PrivateToken, int TransactionId, int BetTransactionId, decimal Amount,out TokenModel Model)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "cancelbett";
            var parameters = new DynamicParameters();
            parameters.Add("token", PrivateToken);
            parameters.Add("transactionid", TransactionId);
            parameters.Add("bettransactionid", BetTransactionId);
            parameters.Add("amount", Amount);
            parameters.Add("currentbalance", dbType:DbType.Decimal,direction:ParameterDirection.Output);
            parameters.Add("check", dbType:DbType.Int32,direction:ParameterDirection.ReturnValue);
            connection.Execute(procedurename,parameters,commandType:CommandType.StoredProcedure);
            Model = new TokenModel();
            Model.CurrentBalance = parameters.Get<decimal?>("@currentbalance");
            Model.Check = parameters.Get<Int32?>("check");

        }
    }
}
