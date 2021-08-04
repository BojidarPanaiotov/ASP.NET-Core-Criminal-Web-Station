namespace Criminal_Web_Station.Models.Api
{
    using System;

    public class ItemApiModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal? Weight { get; set; }

        public string MainImgUrl { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public DateTime CreatedOn { get; init; }
    }
}
