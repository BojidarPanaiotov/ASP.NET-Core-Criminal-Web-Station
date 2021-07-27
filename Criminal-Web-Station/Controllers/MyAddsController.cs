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
        private readonly IColdWeapon coldWeapon;
        public MyAddsController(
            UserManager<Account> userManager,
            ApplicationDbContext context,
            IColdWeapon coldWeapon)
        {
            this.userManager = userManager;
            this.context = context;
            this.coldWeapon = coldWeapon;
        }
        [HttpGet]
        [Authorize]
        public IActionResult CurrentAdds()
        {
            var allUserItems = new List<SingleAddItemModel>();
            var accountId = this.userManager.GetUserAsync(this.User).Result.Id; ;

            var userFirearms = this.context
             .Firearms
             .Where(x => x.AccountId == accountId)
             .Select(x => new SingleAddItemModel
             {
                 Id = x.Id,
                 Name = x.Name,
                 Price = x.Price,
                 CreatedOn = x.CreatedOn,
                 Type = ItemType.Firearm
             })
             .ToList();

            var userColdWeapons = this.context
                .ColdWeapons
                .Where(x => x.AccountId == accountId)
                .Select(x => new SingleAddItemModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    CreatedOn = x.CreatedOn,
                    Type = ItemType.ColdWeapon
                })
                .ToList();
            allUserItems.AddRange(userFirearms);
            allUserItems.AddRange(userColdWeapons);

            return View(allUserItems);
        }
    }
}
