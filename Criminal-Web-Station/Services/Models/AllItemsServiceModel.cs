namespace Criminal_Web_Station.Services.Models
{
    using System.Collections.Generic;

    public class AllItemsServiceModel
    {
        public const int ItemsPerPage = 3;
        public int CurrentPage { get; init; } = 1;
        public int TotalItems { get; init; }
        public string Filter { get; set; }
        public string Sorting { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<ItemMarketModel> Items { get; set; }
        public IEnumerable<CategoryServiceModel> Tags { get; set; }
    }
}
