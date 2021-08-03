using Criminal_Web_Station.Services.Interfaces;
using Criminal_Web_Station.Services.Models;
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
        public IActionResult All([FromQuery()] AllItemsServiceModel query)
        {
            var allItems = this.marketService
                .AllItems(
                query.TagFilter, 
                query.SearchTerm, 
                query.OrderBy,
                query.CurrentPage, 
                AllItemsServiceModel.ItemsPerPage);

            return View(allItems);
        }
    }
}
