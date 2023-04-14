using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BSMVCprj.Services
{
    public class TrasactionLog : ItransactionLOG
    {
        private readonly IConfiguration _config;

        public TrasactionLog(IConfiguration config)
        {
            _config = config;
        }
        public async Task transaction(MoneyTransferM transactionlogmodel, int UserId, string Transtype)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "translog";
            var parameters = new DynamicParameters();
            parameters.Add("transtype", Transtype);
            parameters.Add("amount", transactionlogmodel.Amount);
            parameters.Add("datetime", DateTime.Now);
            parameters.Add("userid", UserId);
            parameters.Add("status", transactionlogmodel.Status);
            await connection.ExecuteAsync(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task TransactionId(MoneyTransferM model,int Userid)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var proceurename = "gettransid";
            var parmeters = new DynamicParameters();
            parmeters.Add("userid", Userid);
            parmeters.Add("TransactionId", dbType: DbType.Guid, direction: ParameterDirection.Output);
            await connection.ExecuteAsync(proceurename, parmeters, commandType: CommandType.StoredProcedure);

            model.TransactionId = parmeters.Get<Guid>("@TransactionId");
        }

        public void UpdateTransaction(MoneyTransferM updatemodel,string procedurename)
        {
            try
            {
                var connection = new SqlConnection(_config.GetConnectionString("name"));
                
                var parameters = new DynamicParameters();
                parameters.Add("amount", updatemodel.Amount);
                parameters.Add("transactionid", updatemodel.TransactionId);
                parameters.Add("status", updatemodel.Status);
                connection.Execute(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                
            }
        }
    }
}
