using System.ComponentModel.DataAnnotations;

namespace Criminal_Web_Station.Data.Entities
{
    public class Firearm:Item
    {
        [Required]
        public int FillerCapacity { get; set; }
    }
}
