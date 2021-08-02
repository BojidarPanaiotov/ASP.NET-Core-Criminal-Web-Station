using Microsoft.AspNetCore.Mvc;

namespace Criminal_Web_Station.Controllers
{
    public class ForumController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
