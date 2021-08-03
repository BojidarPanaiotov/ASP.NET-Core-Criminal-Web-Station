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
        public IActionResult All([FromQuery]AllItemsServiceModel itemModel)
        {
            var allItems = this.marketService
                .AllItems(
                itemModel.Filter, 
                itemModel.SearchTerm, 
                itemModel.Sorting,
                itemModel.CurrentPage, 
                AllItemsServiceModel.ItemsPerPage);

            return View(allItems);
        }
    }
}
