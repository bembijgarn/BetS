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
    public class AUTHservice : IAUTH
    {
        private readonly IConfiguration _config;
        public AUTHservice(IConfiguration config)
        {
            _config = config;
        }
        public void Authentification(out TokenModel Model, string Token, string Status)
        {
           
                var connection = new SqlConnection(_config.GetConnectionString("name"));
               
                var procedurename = "mypw";
                var parameters = new DynamicParameters();
                parameters.Add("token", Guid.Parse(Token));
                parameters.Add("status", Status);
                parameters.Add("privatetoken",dbType: DbType.Guid, direction: ParameterDirection.Output);
                parameters.Add("check",dbType:DbType.Int32,direction:ParameterDirection.ReturnValue);
                connection.Execute(procedurename,param: parameters,commandType:CommandType.StoredProcedure);
                
                Model = new TokenModel();
                Model.TokenId =  parameters.Get<Guid?>("@privatetoken");
                Model.Check = parameters.Get<Int32?>("check");
                
            
        }
    }
}
