using AutoMapper;
using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Models.Item;

namespace Criminal_Web_Station.Services.AutoMapper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Item, ItemInputFormModel>();
        }
    }
}
