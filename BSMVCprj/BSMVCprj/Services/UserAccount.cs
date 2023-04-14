using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BSMVCprj.Services
{
    public class UserAccount : IallUserAccount
    {
        private readonly IConfiguration _config;
        public UserAccount(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<UserAccountM> GetAll()
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "selectall";
            var users = connection.Query<UserAccountM>(procedurename, commandType: System.Data.CommandType.StoredProcedure).ToList();
            return users;
        }
        public async Task Delete(int Id)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "deleteuser";
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            var dbuser = await connection.ExecuteAsync(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
