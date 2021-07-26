using Criminal_Web_Station.Data;
using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Models.Firearm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Criminal_Web_Station.Controllers
{
    public class FirearmController : Controller
    {
        private readonly UserManager<Account> userManager;
        private readonly ApplicationDbContext context;
        public FirearmController(
            UserManager<Account> userManager, 
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(FirearmInputFormModel firearm)
        {
            if (!this.ModelState.IsValid)
            {
                return View(firearm);
            }

            var accountId = this.userManager.GetUserAsync(this.User).Result.Id;

            var firearmEntity = new Firearm
            {
                Name = firearm.Name,
                Price = firearm.Price,
                Weight = firearm.Weight,
                Description = firearm.Description,
                FillerCapacity = firearm.FillerCapacity,
                MainImgUrl = firearm.MainImgUrl,
                AccountId = accountId,
                CreatedOn = DateTime.Now
            };

            await this.context.AddAsync(firearmEntity);
            await this.context.SaveChangesAsync();

            return RedirectToAction("Index","Home");
        }
    }
}
