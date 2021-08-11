namespace Criminal_Web_Station.Areas.Admin.Controllers
{
    using Criminal_Web_Station.Areas.Admin.Models;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class ItemsController : AdminController
    {
        private readonly IItemService itemService;
        private readonly IAdminService adminService;

        public ItemsController(
            IItemService itemService, 
            IAdminService adminService)
        {
            this.itemService = itemService;
            this.adminService = adminService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Statistics()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult ItemDetail(string accountId)
        {
            var currentUserItems = this.itemService
                .GetItemsByAccountIdGeneric<ItemAdminModel>(accountId)
                .ToList();

            var currentUser = new UserItemsAdminModel
            {
                Username = this.adminService.GetUsernameById(accountId),
                Items = currentUserItems
            };

            return View(currentUser);
        }

    }
}
