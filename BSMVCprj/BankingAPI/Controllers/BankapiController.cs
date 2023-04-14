using BankingAPI.Model;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;

namespace BankingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankapiController : ControllerBase
    {
        private readonly IConfiguration _config;
        public BankapiController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("Depo")]
        public async Task<IActionResult> Depo([FromBody]BankingModel mod)
        {
            /* var httpclient = new HttpClient();
             httpclient.BaseAddress = new Uri("https://localhost:44339/Banking/Deposit");
             var response = await httpclient.GetAsync("Banking/Deposit");
             if (response.IsSuccessStatusCode)
             {
                 var responsecontent = response.Content.ReadAsStringAsync();
                 var b = JsonConvert.DeserializeObject<BankingModel>(Convert.ToString(responsecontent));
                 Deposit(b, 1);
             }*/
            await Deposit(mod,1);
            return Ok("succes");
        }
        private async Task<int> Deposit(BankingModel transfer, int Userid)
        {
            var connection = new SqlConnection(_config.GetConnectionString("name"));
            var procedurename = "deposit";
            var parameters = new DynamicParameters();
            parameters.Add("amount", transfer.Amount);
            parameters.Add("userid", Userid);
            var depo = await connection.ExecuteAsync(procedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (depo < 0)
            {
                return depo;
            }
            return 1;
        }
    }


    
}
