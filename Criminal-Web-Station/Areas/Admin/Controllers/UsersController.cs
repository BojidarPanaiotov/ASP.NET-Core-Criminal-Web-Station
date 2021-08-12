namespace Criminal_Web_Station.Areas.Admin.Controllers
{
    using Criminal_Web_Station.Areas.Admin.Models;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : AdminController
    {
        private readonly IAdminService adminService;

        public UsersController(IAdminService adminService)
            => this.adminService = adminService;

        [Authorize]
        [HttpGet]
        public IActionResult All()
        {
            var userWithRoles = this.adminService.GetAllUsers();
            return View(new UsersAdminModel
            {
                Users = userWithRoles
            });
        }
        [Authorize]
        [HttpPost]
        public IActionResult All(UsersAdminModel banInformation)
        {
            var isBanned = this.adminService.MarkUserAsBanned(banInformation.Ban);

            if (isBanned)
            {
                this.TempData[WebConstats.Warning] = string
                    .Format(WebConstats.UserIsBannedInformation,
                    banInformation.Ban.AccountId,
                    banInformation.Ban.Reason,
                    banInformation.Ban.TotalBanSeconds);
            }

            var userWithRoles = this.adminService.GetAllUsers();
            return View(new UsersAdminModel
            {
                Users = userWithRoles
            });
        }
    }
}
