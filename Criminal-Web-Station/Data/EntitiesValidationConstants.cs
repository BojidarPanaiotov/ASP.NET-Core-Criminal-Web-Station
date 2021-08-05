namespace Criminal_Web_Station.Data
{
    public class EntitiesValidationConstants
    {
        public class Item
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;

            public const double PriceMinLength = 0.5;
            public const double PriceMaxLength = 1_000_000_000;

            public const double WeightMinLength = 0.1;
            public const double WeightMaxLength = 2000;

            public const int DescriptionMaxLength = 1000;
        }
        public class Category
        {
            public const int NameMaxLength = 50;
        }
        public class CreditCard
        {
            public const int OwnerNameMinLength = 2;
            public const int OwnerNameMaxLength = 100;

            public const int CvvMinMaxLength = 3;
            public const int CreditCardNumberMinMaxLength = 16;
        }
    }
}
