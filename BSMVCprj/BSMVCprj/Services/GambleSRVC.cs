using BSMVCprj.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;

namespace BSMVCprj.Services
{
    public class GambleSRVC : IGamble
    {
        private readonly IConfiguration _config;
        public GambleSRVC(IConfiguration config)
        {
            _config = config;
        }

        public int RPSLoose(int Id)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "GamblingLoose";
            var parameters = new DynamicParameters();
            parameters.Add("userid", Id);
            var depo = connection.Execute(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (depo < 0)
            {
                return depo;
            }
            return 1;
        }

        public int RPSWin(int Id)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "GamblingWin";
            var parameters = new DynamicParameters();
            parameters.Add("userid", Id);
            var depo = connection.Execute(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (depo < 0)
            {
                return depo;
            }
            return 1;
        }

        public int Slotloose(int Id)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "Slotloose";
            var parameters = new DynamicParameters();
            parameters.Add("userid", Id);
            var depo = connection.Execute(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (depo < 0)
            {
                return depo;
            }
            return 1;
        }

        public int SlotWin(int Id,decimal Win)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "Slotwin";
            var parameters = new DynamicParameters();
            parameters.Add("userid", Id);
            parameters.Add("winamount",Win);
            var depo = connection.Execute(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (depo < 0)
            {
                return depo;
            }
            return 1;
        }
    }
}
