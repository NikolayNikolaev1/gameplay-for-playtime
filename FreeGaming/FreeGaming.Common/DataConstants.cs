namespace FreeGaming.Common
{
    public static class DataConstants
    {
        public const double RangeMinValue = 0.0;

        public const int StringMaxLength = 100;

        public const int StringMinLength = 3;

        public static class GameProperties
        {
            public const int DescriptionMaxLength = 3000;
            public const int DescriptionMinLength = 20;
            public const int DeveloperMaxLength = 50;
            public const int DeveloperMinLength = 6;
            public const double PriceMinValue = 0;
            public const double PriceMaxValue = 1000;
            public const double SizeMinValue = 0;
            public const double SizeMaxValue = 1000;
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 2;
            public const int TrailerIdLength = 11;
        }

        public static class UserProperties
        {
            public const int EmailMaxLength = 320;
            public const int EmailMinLength = 3;
            public const int PasswordMaxLength = 128;
            public const int PasswordMinLength = 3;
            public const int UserNameMaxLength = 20;
            public const int UserNameMinLength = 3;
        }   
    }
}
