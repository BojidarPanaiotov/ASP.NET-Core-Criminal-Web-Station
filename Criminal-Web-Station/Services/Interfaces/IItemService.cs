namespace Criminal_Web_Station.Services.Interfaces
{
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Models;
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Models;
    using global::AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemService
    {
        Task CreateAsync(ItemInputFormModel itemInput, string accountId);
        void EditItem(ItemInputFormModel itemInput, string id);
        Task DeleteItemAsync(string id);
        IEnumerable<CategoryServiceModel> AllCategories();
        T GetItemByIdGeneric<T>(string id, IMapper mapper = null);
        Item GetItemById(string id);
        IEnumerable<T> GetAll<T>();
        IEnumerable<T> GetItemsByAccountIdGeneric<T>(string accountId);
        IEnumerable<SingleAddItemModel> GetAddedItemsById(string id);
        bool DoesThisUserHaveThisItem(string accountId,string itemId);
    }
}
