namespace Criminal_Web_Station.Services.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllItemsServiceModel
    {
        public string TagFilter { get; set; }
        public string OrderBy { get; set; }
        [Display(Name ="Search")]
        public string SearchTerm { get; set; }
        public IEnumerable<ItemMarketModel> Items { get; set; }
        public IEnumerable<CategoryServiceModel> Tags { get; set; }
    }
}
