using AutoMapper;
using AutoMapper.QueryableExtensions;
using Criminal_Web_Station.Data;
using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Services.Interfaces;
using Criminal_Web_Station.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Criminal_Web_Station.Services.Implementations
{
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
        public AllItemsServiceModel AllItems(string tagFilter
            , string searchTerm
            , string OrderBy)
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

            itemsQuery = OrderBy switch
            {
                "Price" => itemsQuery.OrderBy(x => x.Price),
                "Date" => itemsQuery.OrderBy(x => x.CreatedOn),
                _ => itemsQuery.OrderBy(x => x.Id)
            };

            return new AllItemsServiceModel
            {
                Items = GetItems(itemsQuery),
                OrderBy = null,
                SearchTerm = null,
                TagFilter = null,
                Tags = this.context.Categories.ProjectTo<CategoryServiceModel>(this.mapper.ConfigurationProvider)
            };
        }
        private static IEnumerable<ItemMarketModel> GetItems(IQueryable<Item> itemQuery)
            => itemQuery
                .Select(x => new ItemMarketModel
                {
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
    }

}

