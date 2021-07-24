using System;
using System.ComponentModel.DataAnnotations;
using static Criminal_Web_Station.Data.EntitiesValidationConstants.Hitman;
using static Criminal_Web_Station.Data.EntitiesValidationConstants;

namespace Criminal_Web_Station.Data.Entities
{
    public class Hitman
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string MainImgUrl { get; set; }
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
        [Required]
        public string AccountId { get; set; }
        public Account Account { get; init; }
    }
}
