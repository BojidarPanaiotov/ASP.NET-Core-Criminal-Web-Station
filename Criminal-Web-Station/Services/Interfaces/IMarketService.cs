﻿namespace Criminal_Web_Station.Services.Interfaces
{
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Models;
    using System.Collections.Generic;

    public interface IMarketService
    {
        AllItemsServiceModel AllItems(
            string tagFilter,
            string searchTerm,
            ItemSorting sorting,
            int currentPage,
            int itemsPerPage);
        IEnumerable<CategoryServiceModel> GetCategories();
        void RemoveItems(IEnumerable<HomeItemModel> items);
        void AddToPurchaseHistory(IEnumerable<HomeItemModel> cartItems, string accountId);
    }
}
