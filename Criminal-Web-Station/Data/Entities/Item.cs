namespace Criminal_Web_Station.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Criminal_Web_Station.Data.EntitiesValidationConstants.Item;

    public class Item
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? Weight { get; set; }

        [Required]
        public string MainImgUrl { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public Category Category { get; set; }
        public string CategoryId { get; set; }

        [Required]
        public DateTime CreatedOn { get; init; }
        public DateTime LastUpdate { get; set; }
        [Required]
        public string AccountId { get; set; }

        public Account Account { get; init; }
    }
}
