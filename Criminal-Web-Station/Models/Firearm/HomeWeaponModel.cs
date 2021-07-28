using System.ComponentModel.DataAnnotations;

namespace Criminal_Web_Station.Models.Firearm
{
    public class HomeWeaponModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string MainImgUrl { get; set; }
    }
}
