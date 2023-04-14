using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using BSMVCprj.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSMVCprj.Controllers
{
    public class UserController : Controller
    {
        private readonly IallUserAccount _alluser;

        public IEnumerable<UserAccountM> useraccount { get; set; }
        public UserController(IallUserAccount alluser)
        {
            _alluser = alluser;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
              useraccount =   _alluser.GetAll();
                return View(useraccount);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }

        }
        public JsonResult UserList()
        {
            var data = _alluser.GetAll().ToList();
            return new JsonResult(data);
        }
        public JsonResult Delete(int id)
        {
            _alluser.Delete(id);
            return new JsonResult("User Deleted");
        }

        [HttpDelete]
        public async Task<IActionResult> Deleete(int Id)
        {
            try
            {
                await _alluser.Delete(Id);
                return RedirectToAction("/User/Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
