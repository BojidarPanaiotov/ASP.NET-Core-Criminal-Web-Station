using AutoMapper;
using AutoMapper.QueryableExtensions;
using Criminal_Web_Station.Data;
using Criminal_Web_Station.Services.Interfaces;
using Criminal_Web_Station.Services.Models;
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
        public IEnumerable<ItemServiceMarketModel> GetAllItems() => this.context
                .Items
                .ProjectTo<ItemServiceMarketModel>(this.mapper.ConfigurationProvider)
                .ToList();
    }
}
