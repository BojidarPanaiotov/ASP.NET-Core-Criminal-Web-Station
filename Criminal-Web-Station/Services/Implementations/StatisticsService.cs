namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Services.Interfaces;
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
    }
}
