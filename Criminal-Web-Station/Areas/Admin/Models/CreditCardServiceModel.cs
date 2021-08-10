namespace Criminal_Web_Station.Areas.Admin.Models
{
    using System;

    public class CreditCardServiceModel
    {
        public string Number { get; set; }
        public int Cvv { get; set; }
        public DateTime ExpiredOn { get; set; }
        public decimal Balance { get; set; }
    }
}
