namespace Criminal_Web_Station.Areas.Admin.Controllers
{
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
            return View(userWithRoles);
        }
    }
}
