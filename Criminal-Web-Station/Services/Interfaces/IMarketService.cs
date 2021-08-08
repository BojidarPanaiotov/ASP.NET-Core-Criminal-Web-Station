namespace Criminal_Web_Station.Services.Interfaces
{
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMarketService
    {
        AllItemsServiceModel AllItems(string tagFilter
            , string searchTerm
            , string OrderByint,
            int currentPage,
            int itemsPerPage);
        IEnumerable<CategoryServiceModel> GetCategories();
        Task RemoveItems(IEnumerable<HomeItemModel> items);
    }
}
