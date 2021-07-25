using System.ComponentModel.DataAnnotations;
using static Criminal_Web_Station.Data.EntitiesValidationConstants.Firearm;
using static Criminal_Web_Station.Data.EntitiesValidationConstants;

namespace Criminal_Web_Station.Models.Firearm
{
    public class FirearmInputFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name must be between {2} and {1} symbols.")]
        public string Name { get; set; }

        [Required]
        [Range(PriceMinLength,PriceMaxLength,ErrorMessage = "Price must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Range(WeightMinLength,WeightMaxLength,ErrorMessage ="Weight must be between {1} and {2}.")]
        public decimal? Weight { get; set; }

        [Required]
        [Range(FillerCapacityMinLength,FillerCapacityMaxLength,ErrorMessage ="Filler capacity must be between {1} and {2}.")]
        public int FillerCapacity { get; set; }

        [Required]
        [Url]
        public string MainImgUrl { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
