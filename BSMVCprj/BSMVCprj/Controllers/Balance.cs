using BSMVCprj.Models;
using BSMVCprj.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BSMVCprj.Controllers
{
    public class Balance : Controller
    {
        private readonly IBalance _balance;
        public Balance(IBalance balance)
        {
            _balance = balance;
        }
        public async Task<IActionResult> Userbalance(Balancemodel model)
        {
            int Userid = Convert.ToInt32(User.Identity.Name);
            await _balance.GetBalance(model,Userid);
            return new JsonResult(model.Balance);
        }
    }
}
