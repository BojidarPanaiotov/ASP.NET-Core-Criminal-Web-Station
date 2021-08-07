namespace Criminal_Web_Station.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Criminal_Web_Station.Data.EntitiesValidationConstants.CreditCard;
    public class CreditCardFormModel
    {
        [Required]
        [StringLength(CreditCardNumberMinMaxLength, MinimumLength = CreditCardNumberMinMaxLength, ErrorMessage = "Credit card number was invalid. Enter a valid 16 digit number")]
        [Display(Name = "Credit Card Number")]
        public string Number { get; init; }
        [Required]
        //[StringLength(CvvMinMaxLength,MinimumLength = CvvMinMaxLength)]
        [RegularExpression(@"^(\d{3})$", ErrorMessage = "Enter a valid 3 digit CVV")]
        public int Cvv { get; init; }
        [Required]
        public int Year { get; init; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime ExpiredOn { get; init; }
        [Required]
        public int Month { get; init; }
        public string AccountId { get; set; }
    }
}
