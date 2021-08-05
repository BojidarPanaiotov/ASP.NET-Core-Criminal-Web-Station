namespace Criminal_Web_Station.Controllers
{
    using Criminal_Web_Station.Infrastructure;
    using Criminal_Web_Station.Models;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CreditCardController : Controller
    {
        private readonly ICreditCardService creditCardService;

        public CreditCardController(ICreditCardService creditCardService) 
            => this.creditCardService = creditCardService;

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

            var accountId = ClaimsPrincipalExtensions.GetId(this.User);
            creditCard.AccountId = accountId;

            return RedirectToAction("Index","Home");
        }
    }
}
