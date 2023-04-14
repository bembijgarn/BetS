using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using BSMVCprj.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BSMVCprj.Controllers
{
    [Authorize]
    public class TransferController : Controller
    {
        private readonly IMoneyTransfer _transfer;
        private readonly ItransactionLOG _transactionlog;
        public TransferController(IMoneyTransfer transaction, ItransactionLOG transactionlog)
        {
            _transfer = transaction;
            _transactionlog = transactionlog;
        }
        public void OnGet()
        {
        }
        public IActionResult TransferMoney()
        {
            return View();
        }


        [HttpPost]
        public IActionResult TransferMoney(MoneyTransferM transfer,int Id)
        {

            Id = Convert.ToInt32(User.Identity.Name);
            try
            {
                if (!ModelState.IsValid) return View();

                var transfered = _transfer.MoneyTransfer(transfer, Id);
                if (transfered < 0)
                {
                    ViewData["Loginflag"] = "Transaction Failed!";
                    return View();
                }
                string transactiontype = "TransfertoFriend";
                transfer.Status = "Accepted";
                _transactionlog.transaction(transfer, Id, transactiontype);
                TempData["Loginflag"] = "Transaction Completed";
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
      
        public IActionResult Withdraw()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Wiithdraw(MoneyTransferM withdrawmodel)
        {
            try
            {
                var withdraw = _transfer.Withdraw(withdrawmodel, Convert.ToInt32(User.Identity.Name));
                if (withdraw < 0)
                {
                    TempData["Loginflag"] = "Amount is greather than your Balance";
                    return RedirectToAction("Withdraw","Transfer");
                }
                string transactiontype = "Withdraw";
                _transactionlog.transaction(withdrawmodel, Convert.ToInt32(User.Identity.Name), transactiontype);
                TempData["Loginflag"] = "Withdraw Completed";
                return RedirectToAction("Withdraw","Transfer");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
    }
}
