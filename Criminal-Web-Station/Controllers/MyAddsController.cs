using Microsoft.AspNetCore.Mvc;

namespace Criminal_Web_Station.Controllers
{
    public class MyAddsController:Controller
    {
        public IActionResult CurrentAdds()
        {

            return View();
        }
    }
}
