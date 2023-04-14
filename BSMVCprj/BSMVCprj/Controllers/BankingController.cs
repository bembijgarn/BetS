using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Threading;
using BSMVCprj.Helper;

namespace BSMVCprj.Controllers
{
    public class BankingController : Controller
    {
        private readonly ItransactionLOG _transactionlog;
        private readonly IBankRequest _request;
        private readonly Irst _rst;

        public BankingController(ItransactionLOG transactionlog,IBankRequest request,Irst rst)
        {
            _transactionlog = transactionlog;
            _request = request;
            _rst = rst;
        }
        public IActionResult Deposit()
        {
            return View();
        }
        public IActionResult Withdraw()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Wiithdraw(MoneyTransferM Withdraw)
        {
            Withdraw.Status = "Requested";
            int Userid = Convert.ToInt32(User.Identity.Name);
            
            await _request.WithdrawRequest(Withdraw,Userid);
            await _transactionlog.TransactionId(Withdraw,Userid);


            var request = new BankingModel();
            request.Amount = Withdraw.Amount;
            request.TransactionId = Withdraw.TransactionId;

            if (request.Amount % 2 != 0)
            {
                request.Type = "Failed";
                TempData["Fail"] = "Withdraw Failed!";

            }
            else
            {
                request.Type = "Success";
                TempData["Success"] = "Withdraw Completed!";
            }
            string url = "https://localhost:44339/api/api/Withdraw";
            await _rst.Restex(request, url);
           

            Thread.Sleep(4000);
            return new JsonResult(Withdraw.Amount);
        }
        [HttpGet]
        public  async Task<IActionResult> Deeposit(MoneyTransferM Deposit)
        {               
            try
            {
                Deposit.Status = "Requested";
                int Userid = Convert.ToInt32(User.Identity.Name);

                await _request.MoneyRequest(Deposit,Userid);
                await _transactionlog.TransactionId(Deposit, Userid);

                return new JsonResult(Deposit.TransactionId);  
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}

