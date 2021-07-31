namespace Criminal_Web_Station.Services.Interfaces
{
    using Criminal_Web_Station.Services.Models;
    using System.Collections.Generic;

    public interface IMarketService
    {
        AllItemsServiceModel AllItems(string tagFilter
            , string searchTerm
            , string OrderBy);
        IEnumerable<CategoryServiceModel> GetCategories();
    }
}
