namespace Criminal_Web_Station.Data.Entities
{
    using System;
    public class Purchase
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public DateTime PurchaseDate { get; init; }
        public decimal Cost { get; init; }
        public string AccountId { get; init; }
        public Account Account { get; init; }
    }
}
