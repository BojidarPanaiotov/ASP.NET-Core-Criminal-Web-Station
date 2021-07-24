using System;
using System.ComponentModel.DataAnnotations;
using static Criminal_Web_Station.Data.EntitiesValidationConstants.Drug;
using static Criminal_Web_Station.Data.EntitiesValidationConstants;
using Criminal_Web_Station.Data;

namespace Criminal_Web_Station.Data.Entities
{
    public class Drug
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string MainImgUrl { get; set; } 
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string AccountId { get; set; }
        public Account Account { get; init; }
    }
}
