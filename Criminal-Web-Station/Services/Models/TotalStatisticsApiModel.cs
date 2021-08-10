namespace Criminal_Web_Station.Services.Models
{
    public class TotalStatisticsApiModel
    {
        public int TotalUsers { get; set; }
        public int TotalUsersRegisteredToday { get; set; }
        public int TotalItems { get; set; }
        public int TotalItemsAddedToday { get; set; }
        public decimal TotalMoneyIncome { get; set; }
        public decimal TodayMoneyIncome { get; set; }
    }
}
