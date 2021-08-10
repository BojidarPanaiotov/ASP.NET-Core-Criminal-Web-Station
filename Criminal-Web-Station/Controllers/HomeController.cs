namespace Criminal_Web_Station.Controllers
{
    using Criminal_Web_Station.Models;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var mainContext = this.homeService.GetHomePageData();

            return View(mainContext);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
