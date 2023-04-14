using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BSMVCprj.Services
{
    public class Edit : IEdit
    {
        private readonly IConfiguration _config;
        public Edit(IConfiguration config)
        {
            _config = config;
        }
        public void Edituser(UserAccountM user, int Id)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "updateuserbyid";
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            parameters.Add("name", user.Name);
            parameters.Add("lastname", user.Lastname);
            parameters.Add("email", user.Email);
            parameters.Add("username", user.Username);
            parameters.Add("bankcard", user.BankCard);

            var dbuser = connection.Execute(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
