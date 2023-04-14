using BSMVCprj.APIModels;
using BSMVCprj.Models;
using BSMVCprj.Repository.API;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BSMVCprj.Services.API
{
    public class APIUSERservice : IAPIUSER
    {
        private readonly IConfiguration _config;
        public APIUSERservice(IConfiguration config)
        {
            _config = config;
        }


        public   List<UserAccountM> ApiUser(string Token, string Status,out TokenModel token)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "apiuser";
            var parameters = new DynamicParameters();
            parameters.Add("token", Token);
            parameters.Add("status", Status);
            parameters.Add("check",dbType:DbType.Int32,direction:ParameterDirection.ReturnValue);
            var user =  connection.Query<UserAccountM>(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            token = new TokenModel();
            token.Check = parameters.Get<Int32?>("check");
            return user.ToList();
        }
    }
}
