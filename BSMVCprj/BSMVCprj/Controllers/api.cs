using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;

namespace BSMVCprj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class apiController : ControllerBase
    {
        private readonly IBanktransferrequest _bankreq;
        public apiController(IBanktransferrequest bankreq)
        {
            _bankreq = bankreq;
        }

        [HttpPost("Withdraw")]
        public IActionResult Withdraw(BankingModel model)
        {
            var returnmoney = new MoneyTransferM();
            returnmoney.Amount = model.Amount;
            returnmoney.TransactionId = model.TransactionId;

            if (model.Type == "Failed")
            {
                returnmoney.Status = "Rejected";
                _bankreq.Withdraw(returnmoney);
            }
            else
            {
                returnmoney.Status = "Accepted";
                _bankreq.Withdraw(returnmoney);
            }
            return Ok();
        }
        [HttpPost("Deposit")]
        public IActionResult Deposit(BankingModel model)
        {
            var deposit = new MoneyTransferM();
            deposit.Amount = model.Amount;
            deposit.TransactionId = model.TransactionId;
            if (model.Type == "Success")
            {
                
                deposit.Status = "Accepted";
                _bankreq.Deposit(deposit);
                return Ok();
            }
            else
            {
                deposit.Status = "Rejected";
                _bankreq.Deposit(deposit);
                return Ok();
            } 
        }
    }
}
