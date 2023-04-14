using BSMVCprj.Helper;
using BSMVCprj.Interfaces;
using BSMVCprj.Models;
using BSMVCprj.Repository.token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BSMVCprj.Controllers
{
    [Authorize]
    public class Gamble : Controller
    {
        private readonly IToken _token;
        private readonly IGamble _gamble;
        private readonly Irst _rst;

        public Gamble(IGamble gamble,IToken token,Irst rst)
        {
            _gamble = gamble;
            _token = token;
            _rst = rst;
        }
        public async Task<IActionResult> GenerateToken(TokenModel token)
        {
            int Userid = Convert.ToInt32(User.Identity.Name);
            string Status = "Active";
            await   _token.Createtoken(Userid, Status);
            await  _token.GetToken(Userid,Status,token);
            return new JsonResult(token.TokenId);
        }
        public async Task<IActionResult> DeleteToken(TokenModel token)
        {
            int Userid = Convert.ToInt32(User.Identity.Name);
            string Status = "Active";
            await _token.GetToken(Userid, Status,token);
            await _token.DeleteToken(token);
            return new JsonResult(token.TokenId);
        }
        public IActionResult Gambling()
        {
            ViewData["tokenflag"] = "Firstly,You have to generate TOKEN!";
            return View();
        }
        public async Task<IActionResult> PlayRPS(TokenModel model)
        {
            try
            {
                await _token.GetToken(Convert.ToInt32(User.Identity.Name), "Active", model);

                return View();
            }
            catch (Exception)
            {
               
                return RedirectToAction("Gambling");
            }
        }
        public IActionResult RPS(int id)
        {
            try
            {
                var UserBalance = Convert.ToDecimal(User.Claims.Where(x => x.Type == ClaimTypes.Actor).FirstOrDefault().Value);
                if (UserBalance > 10)
                {
                    RPSModel PlayerChoice = new RPSModel() { RPSoption = (Option)id };
                    RPSModel ComputerChoice = new RPSModel() { RPSoption = (Option)Computedchoice() };
                    string str;

                    str = WinLoose(PlayerChoice, ComputerChoice, true);
                    var choices = $"Player : {PlayerChoice.RPSoption.ToString()}\n Computer {ComputerChoice.RPSoption.ToString()}";
                    ViewBag.Message = str;
                    WinorNot(str);
                    TempData["WinnerFlag"] = str;
                    return View("PlayRPS");
                }
                ViewData["WinnerFlag"] = "Sorry,Insufficient Balance!";
                return View("PlayRPS");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> PlaySlot(TokenModel model)
        {
            try
            {
                await _token.GetToken(Convert.ToInt32(User.Identity.Name), "Active", model);

                return View();
            }
            catch (Exception)
            {
                
                return RedirectToAction("Gambling");
            }
        }
        public IActionResult Slot(SlotModel slotmodel)
        {
            var Userbalance = Convert.ToDecimal(User.Claims.Where(x => x.Type == ClaimTypes.Actor).FirstOrDefault().Value);

            var Symbols = new List<string>() { "/photos/slot/apple.png",
                "/photos/slot/casino.png",
            "/photos/slot/watermelon.png"};
            int randomindex;
            randomindex = Computeindex();
            slotmodel.Symbol1 = Symbols[randomindex];
            randomindex = Computeindex();
            slotmodel.Symbol2 = Symbols[randomindex];
            randomindex = Computeindex();
            slotmodel.Symbol3 = Symbols[randomindex];
            decimal winamount;
            if (Userbalance < 10)
            {
                return View("Gambling");
            }
            if (slotmodel.Symbol1 == slotmodel.Symbol2 && slotmodel.Symbol2 == slotmodel.Symbol3)
            {
                if (slotmodel.Symbol1 == Symbols[1])
                {
                    winamount = 5;
                    _gamble.SlotWin(Convert.ToInt32(User.Identity.Name), winamount);
                }
                if (slotmodel.Symbol1 == Symbols[2])
                {
                    winamount = 3;
                    _gamble.SlotWin(Convert.ToInt32(User.Identity.Name), winamount);
                }
                winamount = 2;
                _gamble.SlotWin(Convert.ToInt32(User.Identity.Name), winamount);

            }
            _gamble.Slotloose(Convert.ToInt32(User.Identity.Name));

            return new JsonResult(slotmodel);

        }

        #region RPS

        private int Computedchoice()
        {
            var ran = new Random();
            return ran.Next(0, 3);
        }
        private string WinLoose(RPSModel p1, RPSModel p2, bool type)
        {
            var player = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;
            string output = "The Winner Is : ";
            if ((int)p2.RPSoption == (int)(p1.RPSoption + 1) % 3) output += "Computer!";
            else if ((int)p1.RPSoption == (int)(p2.RPSoption + 1) % 3) output += $"{player}";
            else output += "It is a Draw!";
            return output;
        }
        private void WinorNot(string result)
        {
            if (result == $"The Winner Is : {User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value}")
            {
                _gamble.RPSWin(Convert.ToInt32(User.Identity.Name));
            }
            if (result == $"The Winner Is : Computer!")
            {
                _gamble.RPSLoose(Convert.ToInt32(User.Identity.Name));
            }
        }
        #endregion
        #region slot
        public int Computeindex()
        {
            var random = new Random();
            return random.Next(0, 3);
        }
        #endregion
    }
}
