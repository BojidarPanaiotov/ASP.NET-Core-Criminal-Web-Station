using Criminal_Web_Station.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Criminal_Web_Station.Controllers
{
    public class MarketController : Controller
    {
        private readonly IMarketService marketService;

        public MarketController(IMarketService marketService)
        {
            this.marketService = marketService;
        }
        [HttpGet]
        public IActionResult All()
        {
            var allItems = this.marketService.GetAllItems();

            return View(allItems);
        }
    }
}
