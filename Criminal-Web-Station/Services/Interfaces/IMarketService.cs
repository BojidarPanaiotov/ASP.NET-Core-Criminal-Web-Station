namespace Criminal_Web_Station.Services.Interfaces
{
    using Criminal_Web_Station.Services.Models;
    using System.Collections.Generic;

    public interface IMarketService
    {
        IEnumerable<ItemServiceMarketModel> GetAllItems();
    }
}
