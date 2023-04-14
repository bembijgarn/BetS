using BankingMVC.Helper;
using BankingMVC.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BankingMVC.Controllers
{
    public class DepositController : Controller
    {
        private readonly IConfiguration _config;
        private readonly Irst _rst;
        public DepositController(IConfiguration config,Irst rst)
        {
            _config = config;
            _rst = rst;
        }
        public IActionResult Deposit(Bankingmodel model)
        {
            return View(model);
        }
        public async Task<IActionResult> Deeposit(Bankingmodel model)
        {
            if (model.Amount != 0) 
            {
                model.Type = "Success";
            }
            else
            {
                model.Type = "Failed";
            }
            string url = "https://localhost:44339/api/api/Deposit";
            await _rst.Restex(model,url);

            return new JsonResult(model);
        }
        private async Task Restex(Bankingmodel request, string url)
        {
            var client = new RestClient(url);

            var requestt = new RestRequest();
            requestt.Method = Method.Post;
            requestt.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(request);
            requestt.AddParameter("application/json", body, ParameterType.RequestBody);
            await client.ExecuteAsync(requestt);
        }


    }
}
