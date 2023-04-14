using BSMVCprj.Models;
using BSMVCprj.Repository.API;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Threading.Tasks;

namespace BSMVCprj.Services.API
{
    public class IWINNservice : IWINN
    {
        private readonly IConfiguration _config;
        public IWINNservice(IConfiguration config)
        {
            _config = config;
        }
        public void Winnzor(string PrivateToken, int TransactionId, string TransType, decimal Amount,out TokenModel model)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "winn";
            var parameters = new DynamicParameters();
            parameters.Add("token", PrivateToken);
            parameters.Add("transid", TransactionId);
            parameters.Add("transtype", TransType);
            parameters.Add("amount", Amount);
            parameters.Add("currentbalance", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("check", dbType: DbType.Decimal, direction: ParameterDirection.ReturnValue);
            connection.Execute(procedurename, parameters, commandType: CommandType.StoredProcedure);
            model = new TokenModel();
            model.CurrentBalance = parameters.Get<decimal?>("@currentbalance");
            model.Check = parameters.Get<Int32?>("check");
        }
    }
}
