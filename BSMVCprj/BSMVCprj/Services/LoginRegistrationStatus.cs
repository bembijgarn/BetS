using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace BSMVCprj.Services
{
    public class LoginRegistrationStatus : ILoginRegistrationStatus
    {
        private readonly IConfiguration _config;
        public LoginRegistrationStatus(IConfiguration config)
        {
            _config = config;
        }
        public IEnumerable<dynamic> Login(LoginM Customer)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "loginuser";
            var parameters = new DynamicParameters();
            parameters.Add("username", Customer.UserName);
            parameters.Add("password", Customer.Password);
            parameters.Add("userid", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            parameters.Add("userbalance", dbType: DbType.Double, direction: ParameterDirection.ReturnValue);
            Customer.Id = parameters.Get<int>("@userid");
            var dbuser = connection.Query(procedurename, parameters, commandType: CommandType.StoredProcedure);
            return dbuser;
        }


        public void Registration(RegistrationM reguser)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "useradd";
            var parameters = new DynamicParameters();
            parameters.Add("name", reguser.Name);
            parameters.Add("lastname", reguser.LastName);
            parameters.Add("email", reguser.Email);
            parameters.Add("identityid", reguser.IdentityId);
            parameters.Add("username", reguser.UserName);
            parameters.Add("password", reguser.Password);
            parameters.Add("balance", 0);
            parameters.Add("bankcard", reguser.BankCard);

            connection.Execute(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
