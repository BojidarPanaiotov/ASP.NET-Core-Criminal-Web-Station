using Criminal_Web_Station.Data;
using Criminal_Web_Station.Models;
using Criminal_Web_Station.Models.Item;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Criminal_Web_Station.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var weapons = this.context
                .Items
                .Take(3)
                .Select(x => new HomeItemModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    MainImgUrl = x.MainImgUrl
                })
                .ToList();

            return View(weapons);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
