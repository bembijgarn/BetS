using Microsoft.AspNetCore.Mvc;

namespace BankPayment.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
