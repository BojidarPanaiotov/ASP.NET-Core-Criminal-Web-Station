using Criminal_Web_Station.Data;
using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Models.Item;
using Criminal_Web_Station.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Criminal_Web_Station.Controllers
{
    public class ItemController : Controller
    {
        private readonly UserManager<Account> userManager;
        private readonly ApplicationDbContext context;
        private readonly IItemService itemService;
        public ItemController(
            UserManager<Account> userManager,
            ApplicationDbContext context, 
            IItemService itemService)
        {
            this.userManager = userManager;
            this.context = context;
            this.itemService = itemService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ItemInputFormModel item)
        {
            if (!this.ModelState.IsValid)
            {
                return View(item);
            }

            var accountId = this.userManager.GetUserAsync(this.User).Result.Id;

            await itemService.CreateAsync(item, accountId);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize]
        public IActionResult Edit(string id)
        {
            var itemEditModel = this.itemService.GetItemByIdGeneric<ItemInputFormModel>(id);

            return View(itemEditModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(ItemInputFormModel itemInput, string id)
        {
            if (!this.ModelState.IsValid)
            {
                return View(itemInput);
            }

            this.itemService.EditItemAsync(itemInput, id);

            return RedirectToAction("CurrentAdds", "MyAdds");
        }
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            await this.itemService.DeleteItemAsync(id);

            return RedirectToAction("CurrentAdds", "MyAdds");
        }
        [HttpGet]
        [Authorize]
        public IActionResult Details(string id)
        {
            var itemEntity = this.itemService.GetItemByIdGeneric<ItemInputFormModel>(id);

            return View(itemEntity);
        }
    }
}
