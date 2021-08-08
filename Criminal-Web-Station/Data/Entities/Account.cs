namespace Criminal_Web_Station.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class Account : IdentityUser
    {
        public string CreditCardId {get;init;}
        public CreditCard CreditCard { get; init; }
        public DateTime CreatedOn { get; init; } = DateTime.Now;
        public IEnumerable<Item> Items { get; init; } = new HashSet<Item>();
        public IEnumerable<Purchase> Purchases { get; init; } = new HashSet<Purchase>();
    }
}
