namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Services.Interfaces;
    using Criminal_Web_Station.Services.Models;
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;

    public class PurchaseService : IPurchaseService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PurchaseService(
            ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<PurchaseServiceModel> GetAllPurchasesById(string accountId)
                => this.context
                .Purchases
                .Where(x => x.AccountId == accountId)
                .ProjectTo<PurchaseServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();
    }
}
