using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BSMVCprj.Services
{
    public class Transactionstory : IallTransaction
    {
        private readonly IConfiguration _config;
        public Transactionstory(IConfiguration config)
        {
            _config = config;
        }
        public IEnumerable<TransactionstoryM> Getalltran(DatetimeModel datetime,int Userid)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "transtory";
            var parameters = new DynamicParameters();
            parameters.Add("userid",Userid);
            parameters.Add("startdate", datetime.StartDate);
            parameters.Add("enddate", datetime.EndDate);
            var dbtransactions = connection.Query<TransactionstoryM>(procedurename, parameters,commandType: System.Data.CommandType.StoredProcedure).ToList();
            return dbtransactions;
        }
    }
}
