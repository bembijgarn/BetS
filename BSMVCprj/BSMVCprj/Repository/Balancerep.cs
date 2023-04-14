using BSMVCprj.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BSMVCprj.Repository
{
    public class Balancerep : IBalance
    {
        private readonly IConfiguration _config;
        public Balancerep(IConfiguration config)
        {
            _config = config;
        }
        public async Task GetBalance(Balancemodel balance,int Userid)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "getuserbalance";
            var parameters = new DynamicParameters();
            parameters.Add("userid",Userid);
            parameters.Add("balance", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            await connection.ExecuteAsync(procedurename,parameters,commandType:CommandType.StoredProcedure);
            balance.Balance = parameters.Get<decimal>("@balance");
        }
    }
}
