namespace Criminal_Web_Station.Controllers
{
    using Criminal_Web_Station.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CreditCardController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Index(CreditCardFormModel creditCard)
        {
            if (!this.ModelState.IsValid)
            {
                return View(creditCard);
            }
            return RedirectToAction("Index","Home");
        }
    }
}
