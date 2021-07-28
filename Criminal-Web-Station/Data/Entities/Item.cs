using System;
using System.ComponentModel.DataAnnotations;
using static Criminal_Web_Station.Data.EntitiesValidationConstants;

namespace Criminal_Web_Station.Data.Entities
{
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
        public DateTime CreatedOn { get; set; }
        [Required]
        public string AccountId { get; set; }

        public Account Account { get; init; }
    }
}
