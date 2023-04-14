using BSMVCprj.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using System;
using BSMVCprj.Models;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace BSMVCprj.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly IallTransaction _trans;
        [BindProperty]
        public DatetimeModel datetime { get; set; }

        public TransactionController(IallTransaction trans)
        {
            _trans = trans;
        }
        public IActionResult Transactions()
        {
            return View();
        }

        [HttpPost]
        public JsonResult gettransactions(DatetimeModel mod) 
        {
            
            var Id = Convert.ToInt32(User.Identity.Name);
            var data = _trans.Getalltran(mod, Id);
            return new JsonResult(data);
        }
        public JsonResult getdate(DatetimeModel mod)
        {
            var b = mod.StartDate;
            return new JsonResult("asd");
        }
    }
}
