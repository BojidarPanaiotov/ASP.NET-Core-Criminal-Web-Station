namespace Criminal_Web_Station.Services.AutoMapper
{
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Models;
    using Criminal_Web_Station.Models.Api;
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Models;
    using global::AutoMapper;

    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Item, ItemInputFormModel>();
            CreateMap<Item, AllItemsServiceModel>();
            CreateMap<Item, ItemMarketModel>();
            CreateMap<Category, CategoryServiceModel>();
            CreateMap<Item, HomeItemModel>();
            CreateMap<Item, ItemApiModel>();
            CreateMap<Item, SingleAddItemModel>();
            CreateMap<CreditCard, CreditCardFormModel>();
            CreateMap<Purchase, PurchaseServiceModel>();
        }
    }
}
