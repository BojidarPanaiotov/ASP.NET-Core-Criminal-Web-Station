namespace Criminal_Web_Station.Services.Interfaces
{
    public interface IStatisticsService
    {
        int TotalUsers();
        int TotalAdds();
        int TotalItemsSold();
        decimal TotalAmountOfAllPurchases();
        decimal TotalSiteIncome();
        int UsersRegisteredToday();
        int AddsAddedToday();
        int PurchasesToday();
        decimal MoneySpendToday();

        decimal TodaySiteIncome();
    }
}
