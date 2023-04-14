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
    public class BETTservice : IBETT
    {
        private readonly IConfiguration _config;
        public BETTservice(IConfiguration config)
        {
            _config = config;
        }
        public async Task Bettzor(string PrivateToken, int TransactionId, string TransType, decimal Amount, TokenModel model)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "bett";
            var parameters = new DynamicParameters();
            parameters.Add("token",PrivateToken);
            parameters.Add("transid",TransactionId);
            parameters.Add("transtype",TransType);
            parameters.Add("amount",Amount);
            parameters.Add("currentbalance",dbType:DbType.Decimal,direction:ParameterDirection.Output);
            parameters.Add("check", dbType: DbType.Decimal, direction: ParameterDirection.ReturnValue);
            await connection.ExecuteAsync(procedurename,parameters,commandType:CommandType.StoredProcedure);

            model.CurrentBalance = parameters.Get<decimal?>("@currentbalance");
            model.Check = parameters.Get<Int32?>("check");
        }
    }
}
