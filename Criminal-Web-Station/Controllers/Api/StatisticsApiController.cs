namespace Criminal_Web_Station.Controllers.Api
{
    using Criminal_Web_Station.Services.Interfaces;
    using Criminal_Web_Station.Services.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController
    {
        private readonly IHomeService homeService;

        public StatisticsApiController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public StatisticsApiModel Statistics()
            => new StatisticsApiModel
         {
             TotalAccounts = this.homeService.GetAccountsCount(),
             TotalItems = this.homeService.GetItemsCount(),
             TotalItemsAddedToday = this.homeService.GetItemsAddedToday()
         };
    }
}
