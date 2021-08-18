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
            var accountId = ClaimsPrincipalExtensions.GetId(this.User);

            if (this.creditCardService.HasCreditCard(accountId))
            {
                return RedirectToAction("InsertMoney", "CreditCard");
            }

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

            this.creditCardService.Create(creditCard);

            this.TempData[WebConstats.Message] = WebConstats.SuccessfulCreditCardAdd;

            return RedirectToAction("InsertMoney", "CreditCard");
        }
        [Authorize]
        [HttpGet]
        public IActionResult InsertMoney()
        {
            var accountId = ClaimsPrincipalExtensions.GetId(this.User);

            if (!this.creditCardService.HasCreditCard(accountId))
            {
                return NotFound();
            }

            var creditCardViewModel = this.creditCardService.GetCreditCardAsync(accountId);

            return View(creditCardViewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult InsertMoney(CreditCardFormModel creditCard)
        {
            if(creditCard.Amount <= 0)
            {
                this.TempData[WebConstats.Warning] = WebConstats.InvalidAmountToInsert;
                return RedirectToAction("InsertMoney","CreditCard");
            }
            var accountId = ClaimsPrincipalExtensions.GetId(this.User);

            this.creditCardService.AddMoney(accountId, creditCard.Amount);
            this.TempData[WebConstats.Message] = string.Format(WebConstats.SuccessfulTransaction, creditCard.Amount);
            return RedirectToAction("Index", "Home");
        }
    }
}
