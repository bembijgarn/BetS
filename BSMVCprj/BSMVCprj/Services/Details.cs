using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BSMVCprj.Services
{
    public class Details : IDetails
    {

        private readonly IConfiguration _config;
        public Details(IConfiguration config)
        {
            _config = config;
        }
        public IEnumerable<UserAccountM> Getuserinfo(int Id)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "userdetails";
            var parameter = new DynamicParameters();
            parameter.Add("userid",Id);
            var users = connection.Query<UserAccountM>(procedurename, parameter,commandType: System.Data.CommandType.StoredProcedure);
            return users;
        }
    }
}
