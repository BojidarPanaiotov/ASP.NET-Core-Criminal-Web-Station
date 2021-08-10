namespace Criminal_Web_Station.Controllers.Api
{
    using Criminal_Web_Station.Services.Interfaces;
    using Criminal_Web_Station.Services.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsApiController(IStatisticsService statisticsService) 
            => this.statisticsService = statisticsService;

        public TotalStatisticsApiModel Statistics()
            => new TotalStatisticsApiModel
            {
                TotalUsers = this.statisticsService.TotalUsers(),
                TotalItems = this.statisticsService.TotalAdds(),
                TotalItemsAddedToday = this.statisticsService.AddsAddedToday(),
                TodayMoneyIncome = this.statisticsService.TodaySiteIncome(),
                TotalMoneyIncome = this.statisticsService.TotalSiteIncome(),
                TotalUsersRegisteredToday = this.statisticsService.UsersRegisteredToday()
            };
    }
}
