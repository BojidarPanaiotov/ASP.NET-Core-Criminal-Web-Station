namespace Criminal_Web_Station.Services.Models
{
    using System.Collections.Generic;

    public class AllItemsServiceModel
    {
        public const int ItemsPerPage = 6;
        public int CurrentPage { get; init; } = 1;
        public int TotalItems { get; init; }
        public string Filter { get; set; }
        public ItemSorting Sorting { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<ItemMarketModel> Items { get; set; }
        public IEnumerable<CategoryServiceModel> Tags { get; set; }
    }
    public enum ItemSorting
    {
        None = 1,
        Date = 2,
        DateDescending = 3,
        Price = 4,
        PriceDescending = 5,
        Name = 6,
        NameDescending = 7
    }
}
