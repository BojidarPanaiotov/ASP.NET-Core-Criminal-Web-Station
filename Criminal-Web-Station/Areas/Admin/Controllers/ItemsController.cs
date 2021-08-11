namespace Criminal_Web_Station.Areas.Admin.Controllers
{
    using Criminal_Web_Station.Areas.Admin.Models;
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

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
                Id = accountId,
                Username = this.adminService.GetUsernameById(accountId),
                Items = currentUserItems
            };

            return View(currentUser);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var itemEditModel = this.itemService.GetItemByIdGeneric<ItemInputFormModel>(id);
            itemEditModel.Categories = this.itemService.AllCategories();

            return View(itemEditModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(ItemInputFormModel itemInput, string id)
        {
            if (!this.ModelState.IsValid)
            {
                itemInput.Categories = this.itemService.AllCategories();
                return View(itemInput);
            }

            this.itemService.EditItem(itemInput, id);
            this.TempData[WebConstats.Message] = WebConstats.ItemHasBeenEdited;

            return RedirectToAction("ItemDetail", "Items", new { area = AdminConstants.AreaName, id = id,accountId = itemInput.AccountId });
        }
        [Authorize]
        public async Task<IActionResult> Delete(string id,string accountId)
        {
            await this.itemService.DeleteItemAsync(id);
            this.TempData[WebConstats.Warning] = WebConstats.ItemHasBeenDeleted;

            return RedirectToAction("ItemDetail", "Items", new { area = AdminConstants.AreaName, id = id, accountId = accountId });
        }
    }
}
