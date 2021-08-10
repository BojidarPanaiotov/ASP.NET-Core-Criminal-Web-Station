namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Interfaces;
    using Criminal_Web_Station.Services.Models;
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MarketService : IMarketService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public MarketService(
            ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public AllItemsServiceModel AllItems(
            string tagFilter,
            string searchTerm,
            ItemSorting sorting,
            int currentPage,
            int itemsPerPage)
        {
            var itemsQuery = this.context.Items.AsQueryable();

            if (!string.IsNullOrWhiteSpace(tagFilter) && tagFilter != "All")
            {
                itemsQuery = itemsQuery
                    .Where(i => i.Category.Name == tagFilter);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                itemsQuery = itemsQuery.Where(i =>
                    (i.Name).ToLower().Contains(searchTerm.ToLower()) ||
                    i.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            itemsQuery = sorting switch
            {
                ItemSorting.Price => itemsQuery.OrderBy(x => x.Price),
                ItemSorting.PriceDescending => itemsQuery.OrderByDescending(x => x.Price),
                ItemSorting.Date => itemsQuery.OrderBy(x => x.CreatedOn),
                ItemSorting.DateDescending => itemsQuery.OrderByDescending(x => x.CreatedOn),
                ItemSorting.Name => itemsQuery.OrderBy(x => x.Name),
                ItemSorting.NameDescending => itemsQuery.OrderByDescending(x => x.Name),
                ItemSorting.None or _ => itemsQuery.OrderBy(x => x.Id)
            };

            var totalItems = itemsQuery.Count();

            var items = GetItems(itemsQuery
                .Skip((currentPage - 1) * itemsPerPage)
                .Take(itemsPerPage));

            return new AllItemsServiceModel
            {
                Items = items,
                CurrentPage = currentPage,
                TotalItems = totalItems,
                SearchTerm = searchTerm,
                Filter = tagFilter,
                Sorting = sorting,
                Tags = this.context
                .Categories
                .ProjectTo<CategoryServiceModel>(this.mapper.ConfigurationProvider)
            };
        }
        private static IEnumerable<ItemMarketModel> GetItems(IQueryable<Item> itemQuery)
            => itemQuery
                .Select(x => new ItemMarketModel
                {
                    Id = x.Id,
                    AccountUsername = x.Account.UserName,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    MainImgUrl = x.MainImgUrl,
                    CategoryName = x.Category.Name
                })
                .ToList();
        public IEnumerable<CategoryServiceModel> GetCategories()
            =>
            this.context
            .Categories
            .ProjectTo<CategoryServiceModel>(this.mapper.ConfigurationProvider);

        public void RemoveItems(IEnumerable<HomeItemModel> items)
        {
            foreach (var item in items)
            {
                var itemEntity = this.context.Items.FirstOrDefault(x => x.Id == item.Id);
                this.context.Items.Remove(itemEntity);
            }

            this.context.SaveChanges();
        }

        public void AddToPurchaseHistory(IEnumerable<HomeItemModel> cartItems, string accountId)
        {
            var purchases = cartItems
                .Select(x => new Purchase
                {
                    Name = x.Name,
                    Cost = x.Price,
                    PurchaseDate = DateTime.Now,
                    AccountId = accountId
                }).ToList();

            this.context.Purchases.AddRange(purchases);
            this.context.SaveChanges();
        }
    }

}

