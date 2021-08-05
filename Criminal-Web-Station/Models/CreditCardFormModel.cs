namespace Criminal_Web_Station.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Criminal_Web_Station.Data.EntitiesValidationConstants.CreditCard;
    public class CreditCardFormModel
    {
        [Required]
        [StringLength(OwnerNameMaxLength, MinimumLength = OwnerNameMinLength)]
        [Display(Name = "Name")]
        public string CardOwner { get; init; }
        [Required]
        [StringLength(CreditCardNumberMinMaxLength, MinimumLength = CreditCardNumberMinMaxLength, ErrorMessage = "Credit card number was invalid. Enter a valid 16 digit number")]
        [Display(Name = "Credit Card Number")]
        public string Number { get; init; }
        [Required]
        [StringLength(CvvMinMaxLength,MinimumLength = CvvMinMaxLength)]
        [RegularExpression(@"^(\d{3})$", ErrorMessage = "Enter a valid 3 digit CVV")]
        public string Cvv { get; init; }
        [Required]
        public int Year { get; init; }
        [Required]
        public int Month { get; init; }
        [Required]
        public int AccountId { get; init; }
    }
}
