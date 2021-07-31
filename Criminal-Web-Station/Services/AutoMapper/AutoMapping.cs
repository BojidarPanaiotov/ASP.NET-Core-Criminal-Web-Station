using AutoMapper;
using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Models.Item;
using Criminal_Web_Station.Services.Models;

namespace Criminal_Web_Station.Services.AutoMapper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Item, ItemInputFormModel>();
            CreateMap<Item, ItemServiceMarketModel>();
        }
    }
}
