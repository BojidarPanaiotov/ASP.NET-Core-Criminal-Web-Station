using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Models.Firearm;
using Criminal_Web_Station.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Criminal_Web_Station.Controllers
{
    public class ColdWeapon : Controller
    {
        private readonly UserManager<Account> userManager;
        private readonly IColdWeapon coldWeaponService;
        public ColdWeapon(
            UserManager<Account> userManager,
            IColdWeapon coldWeaponService)
        {
            this.userManager = userManager;
            this.coldWeaponService = coldWeaponService;
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
        private string GetUserId()
            => this.userManager.GetUserId(this.User);
    }
}
