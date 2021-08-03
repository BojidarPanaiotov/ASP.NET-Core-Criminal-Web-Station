namespace Criminal_Web_Station.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class SingleAddItemModel
    {
        [Required]
        public string Id { get; init; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        public string CategoryName { get; set; }
    }
}
