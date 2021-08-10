namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Services.Interfaces;
    using System;
    using System.Linq;

    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext context;

        public StatisticsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int TotalUsers()
            => this.context
            .Accounts
            .Count();
        public int TotalAdds()
            => this.context
            .Items
            .Count();
        public int TotalItemsSold()
            => this.context
            .Purchases
            .Count();

        public decimal TotalAmountOfAllPurchases()
            => this.context
                   .Purchases
                   .Sum(p => p.Cost);

        public decimal TotalSiteIncome()
            => (TotalAmountOfAllPurchases() / 100) * 5;

        public int UsersRegisteredToday()
            => this.context
            .Accounts
            .Where(u => u.CreatedOn.Date == DateTime.Now.Date)
            .Count();
        public int AddsAddedToday()
            => this.context
            .Items
            .Where(x => x.CreatedOn.Date == DateTime.Now.Date)
            .Count();

        public int PurchasesToday()
            => this.context
            .Purchases
            .Where(p => p.PurchaseDate.Date == DateTime.Now.Date)
            .Count();

        public decimal MoneySpendToday()
            => this.context
            .Purchases
            .Where(p => p.PurchaseDate.Date == DateTime.Now.Date)
            .Sum(p => p.Cost);

        public decimal TodaySiteIncome()
        {
            var todayPurchaseAmount = this.context
              .Purchases
              .Where(p => p.PurchaseDate.Date == DateTime.Now.Date)
              .Sum(p => p.Cost);

            var dailySiteIncome = (todayPurchaseAmount / 100) * 5;

            return dailySiteIncome;
        }
    }
}
