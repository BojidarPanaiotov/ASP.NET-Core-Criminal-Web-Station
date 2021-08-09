namespace Criminal_Web_Station.Controllers
{
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Infrastructure;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    public class MyAddsController : Controller
    {
        private readonly UserManager<Account> userManager;
        private readonly IItemService itemService;
        private readonly IPurchaseService purchaseService;
        public MyAddsController(
            UserManager<Account> userManager,
            IItemService coldWeapon,
            IPurchaseService purchaseService)
        {
            this.userManager = userManager;
            this.itemService = coldWeapon;
            this.purchaseService = purchaseService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult CurrentAdds()
        {
            var accountId = this.userManager.GetUserAsync(this.User).Result.Id; ;

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
