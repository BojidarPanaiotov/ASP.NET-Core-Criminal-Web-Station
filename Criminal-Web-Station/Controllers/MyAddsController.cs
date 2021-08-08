namespace Criminal_Web_Station.Controllers
{
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    public class MyAddsController : Controller
    {
        private readonly UserManager<Account> userManager;
        private readonly IItemService itemService;
        public MyAddsController(
            UserManager<Account> userManager,
            IItemService coldWeapon)
        {
            this.userManager = userManager;
            this.itemService = coldWeapon;
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
            return View();
        }
    }
}
