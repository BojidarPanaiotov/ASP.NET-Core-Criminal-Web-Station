using Microsoft.AspNetCore.Mvc;

namespace Criminal_Web_Station.Areas.Admin.Controllers
{
    public class ItemController:AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
