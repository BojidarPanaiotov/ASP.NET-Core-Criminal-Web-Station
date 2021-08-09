namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Interfaces;
    using Criminal_Web_Station.Services.Models;
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HomeService(
            ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int GetAccountsCount()
            => this.context
            .Accounts.Count();

        public int GetItemsCount()
            => this.context
            .Items.Count();

        public int GetItemsAddedToday()
            => this.context
            .Items
            .Where(x => x.CreatedOn.Date.Day == DateTime.Now.Date.Day &&
            x.CreatedOn.Date.Month == DateTime.Now.Date.Month &&
            x.CreatedOn.Date.Year == DateTime.Now.Date.Year)
            .Count();

        public HomeServiceModel GetMainContext()
            => new HomeServiceModel
            {
                TopThreeItems = this.TopThreeItems<HomeItemModel>().ToList(),
                TotalAdds = this.GetItemsCount(),
                TotalUsers = this.GetAccountsCount()
            };

        public IEnumerable<T> TopThreeItems<T>()
            => (IEnumerable<T>)this.context
                .Items
                .Take(3)
                .OrderByDescending(x => x.CreatedOn)
                .ProjectTo<HomeItemModel>(this.mapper.ConfigurationProvider)
                .ToList();
    }
}
