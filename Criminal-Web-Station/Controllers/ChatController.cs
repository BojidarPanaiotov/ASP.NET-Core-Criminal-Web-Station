namespace Criminal_Web_Station.Controllers
{
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    public class ChatController : Controller
    {
        private readonly UserManager<Account> userManager;

        public ChatController(UserManager<Account> userManager)
        {
            this.userManager = userManager;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Messages()
        {
            var userId = this.userManager.GetUserAsync(this.User).Result.Id;
            var userViewModel = new UserChatInputModel
            {
                Id = userId
            };

            return View(userViewModel);
        }
    }
}
