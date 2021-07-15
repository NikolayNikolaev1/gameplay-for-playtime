namespace FreeGaming.Common
{
    public static class WebConstants
    {
        public const int UsersPageSize = 10;

        public static class AdminCredentials
        {
            // Testing credentials.
            public const string Email = "admin@freegaming.test";
            public const string Password = "admin123";
            public const string Username = "Admin";
        }

        public static class ErrorMessages
        {
            public const string InvalidUserPropertyMaxLength = "{0} max length can be {1} characters long.";
            public const string InvalidUserPropertyMinLength = "{0} length must be atleast {1} characters long.";
        }

        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Publisher = "Publisher";
        }
    }
}
