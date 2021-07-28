namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Interfaces;
    using System;
    using System.Threading.Tasks;
    using Criminal_Web_Station.Data;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using global::AutoMapper;

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
                CreatedOn = DateTime.Now,
                LastUpdate = DateTime.Now
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
        public void EditItemAsync(ItemInputFormModel itemInput, string id)
        {
            var itemEntity = this.GetItemById(id);

            itemEntity.Name = itemInput.Name;
            itemEntity.Price = itemInput.Price;
            itemEntity.MainImgUrl = itemInput.MainImgUrl;
            itemEntity.Description = itemInput.Description;
            itemEntity.Weight = itemInput.Weight;
            itemEntity.LastUpdate = DateTime.Now;

            this.context.SaveChanges();
        }
        public Item GetItemById(string id)
            => this.context
            .Items
            .Find(id);
        public T GetItemByIdGeneric<T>(string itemId, IMapper mapper = null)
        {
            var itemEntiry = this.context
            .Items
            .Where(x => x.Id == itemId)
            .FirstOrDefault();

            return this.mapper
                .Map<T>(itemEntiry);
        }
    }
}
