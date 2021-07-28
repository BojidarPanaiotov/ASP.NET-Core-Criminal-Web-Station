using System.ComponentModel.DataAnnotations;

namespace Criminal_Web_Station.Models.Item
{
    public class HomeItemModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string MainImgUrl { get; set; }
    }
}
