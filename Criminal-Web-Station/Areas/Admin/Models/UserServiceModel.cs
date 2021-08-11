namespace Criminal_Web_Station.Areas.Admin.Models
{
    using System;

    public class UserServiceModel
    {
        public string AccountId { get; init; }
        public string Username { get; set; }
        public DateTime CreadtedOn { get; set; }
        public CreditCardServiceModel CreditCard { get; set; }
        public int ItemsCount { get; set; }
        public int PurchasesCount { get; set; }
    }
}
