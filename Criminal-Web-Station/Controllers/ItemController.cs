namespace Criminal_Web_Station.Controllers
{
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Interfaces;
    using Criminal_Web_Station.Services.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ItemController : Controller
    {
        private readonly UserManager<Account> userManager;
        private readonly IItemService itemService;
        private readonly IMarketService marketService;
        public ItemController(
            UserManager<Account> userManager,
            IItemService itemService,
            IMarketService marketService)
        {
            this.userManager = userManager;
            this.itemService = itemService;
            this.marketService = marketService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View(new ItemInputFormModel
            {
                Categories = this.itemService.AllCategories()
            });
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ItemInputFormModel item)
        {
            if (!this.ModelState.IsValid)
            {
                item.Categories = this.itemService.AllCategories();
                return View(item);
            }

            var accountId = this.userManager.GetUserAsync(this.User).Result.Id;

            await itemService.CreateAsync(item, accountId);
            this.TempData.Add(WebConstats.Message, WebConstats.ItemAddMessage);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
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

            return RedirectToAction("CurrentAdds", "MyAdds");
        }

        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            await this.itemService.DeleteItemAsync(id);
            this.TempData[WebConstats.Warning] = WebConstats.ItemHasBeenDeleted;

            return RedirectToAction("CurrentAdds", "MyAdds");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(string id)
        {
            var viewItemModel = this.itemService.GetItemByIdGeneric<ItemInputFormModel>(id);

            var username = this.userManager.FindByIdAsync(viewItemModel.AccountId).Result.UserName;
            viewItemModel.Username = username;

            return View(viewItemModel);
        }
        [HttpGet]
        public IActionResult All(AllItemsServiceModel itemModel)
        {
            var allItems = this.marketService
                .AllItems(
                itemModel.Filter,
                itemModel.SearchTerm,
                itemModel.Sorting,
                itemModel.CurrentPage,
                AllItemsServiceModel.ItemsPerPage);

            return View(allItems);
        }
    }
}
