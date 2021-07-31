namespace Criminal_Web_Station.Services.Models
{
    using System.Collections.Generic;

    public class AllItemsServiceModel
    {
        public string TagFilter { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<ItemMarketModel> Items { get; set; }
        public IEnumerable<CategoryServiceModel> Tags { get; set; }
    }
}
