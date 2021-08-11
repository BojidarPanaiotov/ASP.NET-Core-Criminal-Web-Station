namespace Criminal_Web_Station.Areas.Admin.Models
{
    using System;

    public class ItemAdminModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal? Weight { get; set; }

        public string MainImgUrl { get; set; }

        public string CategoryId { get; set; }

        public DateTime CreatedOn { get; init; }
        public DateTime LastUpdate { get; set; }
    }
}
