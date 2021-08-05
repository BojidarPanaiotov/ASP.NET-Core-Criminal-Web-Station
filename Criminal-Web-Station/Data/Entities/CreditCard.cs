using System;
using System.ComponentModel.DataAnnotations;

namespace Criminal_Web_Station.Data.Entities
{
    public class CreditCard
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        [Required]
        public string Number { get; init; }
        [Required]
        public int Cvv { get; init; }

        [Required]
        public DateTime ExpiredOn { get; init; }
        public string AccountId { get; init; }
        [Required]
        public Account Account { get; init; }
    }
}
