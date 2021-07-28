namespace Criminal_Web_Station.Services.Interfaces
{
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Models;
    using global::AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemService
    {
        Task CreateAsync(ItemInputFormModel itemInput, string accountId);
        void EditItemAsync(ItemInputFormModel itemInput, string id);
        T GetItemByIdGeneric<T>(string characterId, IMapper mapper = null);
        Task DeleteItemAsync(string id);
        IEnumerable<CategoryServiceModel> AllCategories();
    }
}
