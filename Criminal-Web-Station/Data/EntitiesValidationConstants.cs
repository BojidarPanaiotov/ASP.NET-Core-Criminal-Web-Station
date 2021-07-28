namespace Criminal_Web_Station.Data
{
    public class EntitiesValidationConstants
    {
        public const int DescriptionMaxLength = 1000;
        public class Firearm
        {
            public const int FillerCapacityMinLength = 1;
            public const int FillerCapacityMaxLength = 400;
        }
        public class Item
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;

            public const double PriceMinLength = 0.5;
            public const double PriceMaxLength = 1_000_000_000;

            public const double WeightMinLength = 0.1;
            public const double WeightMaxLength = 2000;
        }
        public class Hitman
        {
            public const int NameMaxLength = 50;
        }
    }
}
