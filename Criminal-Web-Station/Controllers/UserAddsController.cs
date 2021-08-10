namespace Criminal_Web_Station.Controllers
{
    using Criminal_Web_Station.Infrastructure;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    public class UserAddsController : Controller
    {
        private readonly IItemService itemService;
        private readonly IPurchaseService purchaseService;
        public UserAddsController(
            IItemService coldWeapon,
            IPurchaseService purchaseService)
        {
            this.itemService = coldWeapon;
            this.purchaseService = purchaseService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult CurrentAdds()
        {
            var accountId = ClaimsPrincipalExtensions.GetId(this.User);

            var result = this.itemService.GetAddedItemsById(accountId);

            return View(result);
        }
        [HttpGet]
        [Authorize]
        public IActionResult PurchaseHistory()
        {
            var accountId = ClaimsPrincipalExtensions.GetId(this.User);

            var purchases = this.purchaseService.GetAllPurchasesById(accountId);
            return View(purchases);
        }
    }
}
