namespace Criminal_Web_Station.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;

    public class UserServiceModel
    {
        public string Username { get; set; }
        public DateTime CreadtedOn { get; set; }
        public CreditCardServiceModel CreditCard { get; set; }
        public IEnumerable<ItemServiceModel> Items { get; set; }
        public IEnumerable<PurchaseAdminModel> Purchases { get; set; }
    }
}
