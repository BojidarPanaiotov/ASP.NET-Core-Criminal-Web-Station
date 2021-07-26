using Criminal_Web_Station.Data;
using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Models.Firearm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var firearmInputFormModel = await this.context.Firearms
                .Where(x => x.Id == id)
                .Select(x => new FirearmInputFormModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    MainImgUrl = x.MainImgUrl,
                    Description = x.Description,
                    FillerCapacity = x.FillerCapacity,
                    Weight = x.Weight
                })
                .FirstOrDefaultAsync();

            return View(firearmInputFormModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(string id, FirearmInputFormModel firearm)
        {
            var firearmEntity = this.context
                .Firearms
                .Find(id);

            firearmEntity.Name = firearm.Name;
            firearmEntity.Price = firearm.Price;
            firearmEntity.Weight = firearm.Weight;
            firearmEntity.MainImgUrl = firearm.MainImgUrl;
            firearmEntity.FillerCapacity = firearm.FillerCapacity;
            firearmEntity.Description = firearm.Description;
            firearmEntity.CreatedOn = DateTime.Now;

            this.context.SaveChanges();

            return RedirectToAction("CurrentAdds", "MyAdds");
        }
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            var firearm = await this.context
                .Firearms
                .FirstOrDefaultAsync(x => x.Id == id);

            if(firearm == null)
            {
                return NotFound();
            }

            this.context.Remove(firearm);
            await this.context.SaveChangesAsync();

            return RedirectToAction("CurrentAdds", "MyAdds");
        }
        [HttpGet]
        [Authorize]
        public IActionResult Details(string id)
        {
            var firearm = this.context
                .Firearms
                .Where(x => x.Id == id)
                .Select(x => new FirearmInputFormModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    FillerCapacity = x.FillerCapacity,
                    MainImgUrl = x.MainImgUrl,
                    Weight = x.Weight
                })
                .FirstOrDefault();

            return View(firearm);
        }
    }
}
