using Criminal_Web_Station.Data;
using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Models;
using Criminal_Web_Station.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Criminal_Web_Station.Controllers
{
    public class MyAddsController : Controller
    {
        private readonly UserManager<Account> userManager;
        private readonly ApplicationDbContext context;
        private readonly IItemService itemService;
        public MyAddsController(
            UserManager<Account> userManager,
            ApplicationDbContext context,
            IItemService coldWeapon)
        {
            this.userManager = userManager;
            this.context = context;
            this.itemService = coldWeapon;
        }
        [HttpGet]
        [Authorize]
        public IActionResult CurrentAdds()
        {
            var accountId = this.userManager.GetUserAsync(this.User).Result.Id; ;

            var userItems = this.context
             .Items
             .Where(x => x.AccountId == accountId)
             .Select(x => new SingleAddItemModel
             {
                 Id = x.Id,
                 Name = x.Name,
                 Price = x.Price,
                 LastUpdate = x.LastUpdate,
                 CategoryName = x.Category.Name
             })
             .ToList();

            return View(userItems);
        }
    }
}
