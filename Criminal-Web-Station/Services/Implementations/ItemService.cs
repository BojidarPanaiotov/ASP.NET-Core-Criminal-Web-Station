﻿namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Models;
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Interfaces;
    using Criminal_Web_Station.Services.Models;
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ItemService(
            ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task CreateAsync(ItemInputFormModel itemInput, string accountId)
        {
            var itemEntity = new Item
            {
                Name = itemInput.Name,
                Price = itemInput.Price,
                Weight = itemInput.Weight,
                Description = itemInput.Description,
                MainImgUrl = itemInput.MainImgUrl,
                AccountId = accountId,
                CategoryId = itemInput.CategoryId,
                CreatedOn = DateTime.Now,
                LastUpdate = DateTime.Now,
            };

            await this.context.AddAsync(itemEntity);
            await this.context.SaveChangesAsync();
        }
        public async Task DeleteItemAsync(string id)
        {
            var itemEntity = await this.context
                .Items
                .FirstOrDefaultAsync(x => x.Id == id);

            this.context.Remove(itemEntity);
            await this.context.SaveChangesAsync();
        }
        public void EditItem(ItemInputFormModel itemInput, string id)
        {
            var itemEntity = this.GetItemById(id);

            itemEntity.Name = itemInput.Name;
            itemEntity.Price = itemInput.Price;
            itemEntity.MainImgUrl = itemInput.MainImgUrl;
            itemEntity.Description = itemInput.Description;
            itemEntity.Weight = itemInput.Weight;
            itemEntity.LastUpdate = DateTime.Now;
            itemEntity.CategoryId = itemInput.CategoryId;

            itemInput.AccountId = itemEntity.AccountId;

            this.context.SaveChanges();
        }
        public Item GetItemById(string id)
            => this.context
            .Items
            .Find(id);

        public T GetItemByIdGeneric<T>(string itemId, IMapper mapper = null)
        {
            var itemEntity = this.context
            .Items
            .Where(x => x.Id == itemId)
            .FirstOrDefault();

            return this.mapper
                .Map<T>(itemEntity);
        }
        public IEnumerable<CategoryServiceModel> AllCategories()
            => this.context
            .Categories
            .Select(x => new CategoryServiceModel
            {
                Id = x.Id,
                Name = x.Name,
            })
            .OrderBy(x => x.Name)
            .ToList();

        public IEnumerable<T> GetAll<T>()
            => this.context
            .Items
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .ToList();

        public IEnumerable<SingleAddItemModel> GetAddedItemsById(string id)
            => this.context
                  .Items
                  .Where(x => x.AccountId == id)
                  .ProjectTo<SingleAddItemModel>(this.mapper.ConfigurationProvider)
                  .ToList();

        public IEnumerable<T> GetItemsByAccountIdGeneric<T>(string accountId)
            => this.context
            .Items
            .Where(x => x.AccountId == accountId)
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .ToList();

        public bool DoesThisUserHaveThisItem(string accounId, string itemId)
            => this.context
            .Accounts
            .Include(a => a.Items)
            .FirstOrDefault(x => x.Id == accounId)
            .Items.Any(i => i.Id == itemId);

    }
}
