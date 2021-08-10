namespace Criminal_Web_Station.Models.Item
{
    using Criminal_Web_Station.Services.Models;
    using System;
    using System.Collections.Generic;
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
        [Display(Name = "Image")]
        public string MainImgUrl { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Tag")]
        public string CategoryId { get; set; }
        public string AccountId { get; set; }
        public string Username { get; set; }
        public IEnumerable<CategoryServiceModel> Categories { get; set; } = new List<CategoryServiceModel>();
    }
}
