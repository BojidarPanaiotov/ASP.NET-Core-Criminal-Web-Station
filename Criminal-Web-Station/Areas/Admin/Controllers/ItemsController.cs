namespace Criminal_Web_Station.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ItemsController : AdminController
    {
        public IActionResult Statistics()
        {
            return View();
        }
    }
}
