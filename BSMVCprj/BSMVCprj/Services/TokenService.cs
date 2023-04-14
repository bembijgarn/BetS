using BSMVCprj.Models;
using BSMVCprj.Repository.token;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BSMVCprj.Services
{
    public class TokenService : IToken
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public async Task Createtoken(int Userid, string Status)
        {

            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "createtoken";
            var parameters = new DynamicParameters();
            parameters.Add("userid",Userid);
            parameters.Add("status",Status);
            await connection.ExecuteAsync(procedurename,parameters,commandType:System.Data.CommandType.StoredProcedure);
           
        }

        public async Task DeleteToken(TokenModel model)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "deletetoken";
            var parameters = new DynamicParameters();
            parameters.Add("tokenid", model.TokenId);
            await connection.ExecuteAsync(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task GetToken(int Userid, string Status, TokenModel token)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "gettoken";
            var parameters = new DynamicParameters();
            parameters.Add("userid", Userid);
            parameters.Add("status", Status);
            parameters.Add("tok", dbType: DbType.Guid, direction: ParameterDirection.Output);
            await  connection.ExecuteAsync(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            token.TokenId = parameters.Get<Guid>("@tok");
        }
    }
   
}
