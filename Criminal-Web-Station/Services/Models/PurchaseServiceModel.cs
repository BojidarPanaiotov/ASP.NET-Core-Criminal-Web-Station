namespace Criminal_Web_Station.Services.Models
{
    using System;
    public class PurchaseServiceModel
    {
        public string Name { get; init; }
        public DateTime PurchaseDate { get; init; }
        public decimal Cost { get; init; }
        public string Status { get; init; }
        public string AccountId { get; init; }
    }
}
