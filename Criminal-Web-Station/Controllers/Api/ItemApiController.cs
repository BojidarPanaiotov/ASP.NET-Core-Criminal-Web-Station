namespace Criminal_Web_Station.Controllers.Api
{
    using Criminal_Web_Station.Models.Api;
    using Criminal_Web_Station.Services.Interfaces;
    using Criminal_Web_Station.Services.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/items")]
    [ApiController]
    public class ItemApiController : ControllerBase
    {
        private readonly IItemService itemService;

        public ItemApiController(
            IItemService itemService)
        {
            this.itemService = itemService;
        }
        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<ItemApiModel>> GetAllItems()
            => this.itemService.GetAll<ItemApiModel>().ToList();
        [HttpGet]
        [Route("Categories")]
        public IEnumerable<CategoryServiceModel> GetAllCategoires()
         => this.itemService.AllCategories();
    }
}
