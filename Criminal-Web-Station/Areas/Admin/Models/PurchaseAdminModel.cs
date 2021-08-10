namespace Criminal_Web_Station.Areas.Admin.Models
{
    using System;

    public class PurchaseAdminModel
    {
        public DateTime PurchaseDate { get; init; }
        public string Name { get; init; }
        public decimal Cost { get; init; }
    }
}
