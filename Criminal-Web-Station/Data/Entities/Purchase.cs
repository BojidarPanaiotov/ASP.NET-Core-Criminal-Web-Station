namespace Criminal_Web_Station.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Purchase
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        [Required]
        public DateTime PurchaseDate { get; init; }
        [Required]
        public string Name { get; init; }
        [Required]
        public decimal Cost { get; init; }
        [Required]
        public string AccountId { get; init; }
        public Account Account { get; init; }
    }
}
