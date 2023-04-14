using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;
using BSMVCprj.Repository.token;

namespace BSMVCprj.Controllers
{
    public class LoginRegistrationController : Controller
    {
        private readonly ILoginRegistrationStatus _registrationStatus;
        [BindProperty]
        public LoginM userinfoo { get; set; }
        private readonly IConfiguration _config;
        private readonly IToken _token;
        public LoginRegistrationController(IConfiguration config, ILoginRegistrationStatus status,IToken token)
        {
            _config = config;
            _registrationStatus = status;
            _token = token;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginM userinfo)
        {
            try
            {
                if (!ModelState.IsValid) return View();

                var connection = new SqlConnection(_config.GetConnectionString("name"));
                var procedurename = "loginuser";
                var parameters = new DynamicParameters();
                parameters.Add("username", userinfoo.UserName);
                parameters.Add("password", userinfoo.Password);
                parameters.Add("userid", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("balance",dbType: DbType.Decimal,direction: ParameterDirection.Output);
                var dbuser = connection.Query(procedurename, parameters, commandType:CommandType.StoredProcedure);
             

                if (dbuser.Count() != 0)
                {
                    userinfoo.Id = parameters.Get<int>("@userid");
                    userinfoo.Balance = parameters.Get<decimal>("@balance");
                    await Cookie();
                    return RedirectToAction("Index","Home");
                }
                ViewData["Loginflag"] = "Username or Password is incorrect!";
                
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationM userinfo)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                _registrationStatus.Registration(userinfo);
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Logout()
        {
            try
            {
                var token = new TokenModel();
                await HttpContext.SignOutAsync("BScookie");
                await _token.GetToken(Convert.ToInt32(User.Identity.Name),"Active",token);
                await _token.DeleteToken(token);
                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private async Task Cookie()
        {
            var claims = new List<Claim> {
                    new Claim (ClaimTypes.Name,userinfoo.Id.ToString()),
                    new Claim (ClaimTypes.NameIdentifier,userinfoo.UserName),
                    new Claim (ClaimTypes.Actor,userinfoo.Balance.ToString()),
            };
            var identity = new ClaimsIdentity(claims, "BScookie");
            ClaimsPrincipal claimsprincipal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("BScookie", claimsprincipal);

        }
    }
}
