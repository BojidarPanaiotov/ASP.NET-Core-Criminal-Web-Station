namespace Criminal_Web_Station_Test.Mocks
{
    using Criminal_Web_Station.Services.Interfaces;
    using Moq;

    public static class StatisticServiceMock
    {
        public static IStatisticsService Instance
        {
            get
            {
                var statisticsServiceMock = new Mock<IStatisticsService>();

                statisticsServiceMock
                    .Setup(s => s.TotalUsers())
                    .Returns(10);
                statisticsServiceMock
                    .Setup(s => s.TotalAdds())
                    .Returns(20);

                return statisticsServiceMock.Object;
            }
        }
    }
}
