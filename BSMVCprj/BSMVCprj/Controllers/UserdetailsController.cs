using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BSMVCprj.Controllers
{
    public class UserdetailsController : Controller
    {
        private readonly IDetails _details;
        private readonly IEdit _edit;
        public UserdetailsController(IDetails details, IEdit edit)
        {
            _details = details;
            _edit = edit;
        }
        public IActionResult Userdetails()
        {
            return View();
        }
        public JsonResult MyDetails(int Id)
        {
            Id = Convert.ToInt32(User.Identity.Name);
            var data = _details.Getuserinfo(Id);
            return new JsonResult(data);
        }
        [HttpPost]
        public JsonResult Edituser(UserAccountM lasa,int Id)
        { 
            Id = Convert.ToInt32(User.Identity.Name);
            _edit.Edituser(lasa,Id);
            return new JsonResult("User updated");
        }
    }
}
