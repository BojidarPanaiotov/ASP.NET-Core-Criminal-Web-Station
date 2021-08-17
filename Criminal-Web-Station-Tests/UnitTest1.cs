namespace Criminal_Web_Station_Tests
{
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System;
    using Xunit;

    public class UnitTest1
    {
        private ApplicationDbContext context;
        private IStatisticsService statisticsService;
        private IHomeService homeService;

        public UnitTest1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(Guid.NewGuid().ToString())
                .Options;

            this.context = new ApplicationDbContext(optionsBuilder);

            this.statisticsService = new Mock<IStatisticsService>();
            this.statisticsService = new Mock<IStatisticsService>();
        }
        [Fact]
        public void ErrorShouldReturnView()
        {

        }
    }
}
