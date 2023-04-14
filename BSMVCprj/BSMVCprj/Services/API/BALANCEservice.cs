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
    public class BALANCEservice : IAPIBALANCE
    {
        private readonly IConfiguration _config;
        public BALANCEservice(IConfiguration config)
        {
            _config = config;
        }
        public void Balance(string Token, string Status,out TokenModel Model)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "apibalance";
            var parameters = new DynamicParameters();
            parameters.Add("token",Token);
            parameters.Add("status", Status);
            parameters.Add("balance", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("check",dbType: DbType.Int32,direction:ParameterDirection.ReturnValue);
            connection.Execute(procedurename,parameters,commandType:CommandType.StoredProcedure);

            Model = new TokenModel();
            Model.CurrentBalance = parameters.Get<decimal?>("@balance");
            Model.Check = parameters.Get<Int32?>("check");
            
        }
    }
}
