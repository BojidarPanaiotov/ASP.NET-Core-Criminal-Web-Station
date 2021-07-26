using Criminal_Web_Station.Data;
using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Criminal_Web_Station.Controllers
{
    public class MyAddsController : Controller
    {
        private readonly UserManager<Account> userManager;
        private readonly ApplicationDbContext context;
        public MyAddsController(
            UserManager<Account> userManager,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult CurrentAdds()
        {
            var accountId = this.userManager.GetUserAsync(this.User).Result.Id;

            var firearms = this.context
                .Firearms
                .Select(x => new SingleAddItemModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    CreatedOn = x.CreatedOn
                })
                .ToList();

            return View(firearms);
        }
    }
}
