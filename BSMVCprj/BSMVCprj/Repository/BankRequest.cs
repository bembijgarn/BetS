using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace BSMVCprj.Repository
{
    public class BankRequest : IBankRequest
    {
        private readonly IConfiguration _config;
        public BankRequest(IConfiguration config)
        {
            _config = config;
        }
        public async Task MoneyRequest(MoneyTransferM model, int Userid)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "requestlog";
            var parameters = new DynamicParameters();
            parameters.Add("userid", Userid);
            parameters.Add("amount", model.Amount);
            parameters.Add("status", model.Status);
            await connection.ExecuteAsync(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task WithdrawRequest(MoneyTransferM model, int Userid)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "requestwithlog";
            var parameters = new DynamicParameters();
            parameters.Add("userid", Userid);
            parameters.Add("amount", model.Amount);
            parameters.Add("status", model.Status);
            await connection.ExecuteAsync(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
