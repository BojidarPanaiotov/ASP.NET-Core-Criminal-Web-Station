using System;
using System.ComponentModel.DataAnnotations;

namespace Criminal_Web_Station.Models
{
    public class SingleAddItemModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
