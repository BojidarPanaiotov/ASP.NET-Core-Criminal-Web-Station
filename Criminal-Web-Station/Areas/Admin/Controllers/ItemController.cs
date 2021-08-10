namespace Criminal_Web_Station.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ItemController : AdminController
    {
        public IActionResult Statistics()
        {
            return View();
        }
    }
}
