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
    public class CHANGEWINNservice : ICHANGEWINN
    {
        private readonly IConfiguration _config;
        public CHANGEWINNservice(IConfiguration config)
        {
            _config = config;
        }
        public void ChangeWinn(string PrivateToken, int TransactionId, int PreviousTranId, decimal Amount, decimal PreviousAmount,out TokenModel Model)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "changewinn";
            var parameters = new DynamicParameters();
            parameters.Add("token",PrivateToken);
            parameters.Add("transactionid",TransactionId);
            parameters.Add("previoustranid",PreviousTranId);
            parameters.Add("amount",Amount);
            parameters.Add("previousamount",PreviousAmount);
            parameters.Add("currentbalance",dbType:DbType.Decimal,direction:ParameterDirection.Output);
            parameters.Add("check",dbType:DbType.Int32,direction:ParameterDirection.ReturnValue);
            connection.Execute(procedurename,parameters,commandType:CommandType.StoredProcedure);
            Model = new TokenModel();
            Model.CurrentBalance = parameters.Get<decimal?>("@currentbalance");
            Model.Check = parameters.Get<Int32?>("check");
        }
    }
}
