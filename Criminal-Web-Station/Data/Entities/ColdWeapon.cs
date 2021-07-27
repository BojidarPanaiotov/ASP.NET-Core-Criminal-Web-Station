using System;
using System.ComponentModel.DataAnnotations;
using static Criminal_Web_Station.Data.EntitiesValidationConstants.ColdWeapon;
using static Criminal_Web_Station.Data.EntitiesValidationConstants;

namespace Criminal_Web_Station.Data.Entities
{
    public class ColdWeapon
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public double? Weight { get; set; }

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
