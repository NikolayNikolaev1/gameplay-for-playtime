namespace FreeGaming.Common
{
    public static class WebConstants
    {
        public const string TempDataErrorMessageKey = "ErrorMessage";
        public const string TempDataSuccessMessageKey = "SuccessMessage";
        public const int GamesPageSize = 5;
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
            public const string GameTitleExists = "Game with title {0} already exists.";

            public const string InvalidGameTrailerIdLength = "Video Id must be exactly 11 characters long.";
            public const string InvalidImageFileExtension = "File extension is invalid. Only files with .jpeg, .jpg and .png are valid.";
            public const string InvalidImageFileLength = "The file is too large. Max image length is 2 MB.";
            public const string InvalidImageFileSignature = "File signature is invalid. Image can not be uploaded.";
            public const string InvalidPropertyMaxLength = "{0} max length can be {1} characters long.";
            public const string InvalidPropertyMinLength = "{0} length must be atleast {1} characters long.";
            public const string PasswordsMissmatch = "The password and confirmation password do not match.";

            public const string PublisherEmailExists = "Publisher with email {0} already exists.";
            public const string PublisherUsernameExists = "Publisher with username {0} already exists.";
        }

        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Publisher = "Publisher";
        }

        public static class SuccessMessages
        {
            public const string PublisherCreation = "Publisher successfully created.";
        }
    }
}
