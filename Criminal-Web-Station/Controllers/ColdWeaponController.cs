using Criminal_Web_Station.Data;
using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Models.Firearm;
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
    public class ColdWeaponController : Controller
    {
        private readonly UserManager<Account> userManager;
        private readonly IColdWeapon coldWeaponService;
        private readonly ApplicationDbContext context;
        public ColdWeaponController(
            UserManager<Account> userManager,
            IColdWeapon coldWeaponService,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.coldWeaponService = coldWeaponService;
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
        public async Task<IActionResult> Create(ColdWeaponInputFormModel coldWeapon)
        {
            if (!this.ModelState.IsValid)
            {
                return View(coldWeapon);
            }

            await this.coldWeaponService.CreateAsync(coldWeapon, GetUserId());

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var coldWeaponInputFormModel = await this.context
                .ColdWeapons
                .Where(x => x.Id == id)
                .Select(x => new ColdWeaponInputFormModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    MainImgUrl = x.MainImgUrl,
                    Description = x.Description,
                    Weight = x.Weight
                })
                .FirstOrDefaultAsync();

            return View(coldWeaponInputFormModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(string id, ColdWeaponInputFormModel firearm)
        {
            var firearmEntity = this.context
                .ColdWeapons
                .Find(id);

            firearmEntity.Name = firearm.Name;
            firearmEntity.Price = firearm.Price;
            firearmEntity.Weight = firearm.Weight;
            firearmEntity.MainImgUrl = firearm.MainImgUrl;
            firearmEntity.Description = firearm.Description;
            firearmEntity.CreatedOn = DateTime.Now;

            this.context.SaveChanges();

            return RedirectToAction("CurrentAdds", "MyAdds");
        }
        [HttpGet]
        [Authorize]
        public IActionResult Details(string id)
        {
            var firearm = this.context
                .ColdWeapons
                .Where(x => x.Id == id)
                .Select(x => new ColdWeaponInputFormModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    MainImgUrl = x.MainImgUrl,
                    Weight = x.Weight
                })
                .FirstOrDefault();

            return View(firearm);
        }
        private string GetUserId()
            => this.userManager.GetUserId(this.User);
    }
}
