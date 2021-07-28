namespace Criminal_Web_Station.Models.Item
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Criminal_Web_Station.Data.EntitiesValidationConstants.Item;

    public class ItemInputFormModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name must be between {2} and {1} symbols.")]
        public string Name { get; set; }

        [Required]
        [Range(PriceMinLength, PriceMaxLength, ErrorMessage = "Price must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Range(WeightMinLength, WeightMaxLength, ErrorMessage = "Weight must be between {1} and {2}.")]
        public decimal? Weight { get; set; }

        [Required]
        [Url]
        public string MainImgUrl { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
