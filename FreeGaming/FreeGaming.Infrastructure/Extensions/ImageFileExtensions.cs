namespace FreeGaming.Infrastructure.Extensions
{
    using System;

    public static class ImageFileExtensions
    {
        private static readonly string ImageFileProperties = "data:image;base64,";

        public static string ConvertToString(byte[] imageFile)
            => string.Concat(
                ImageFileProperties,
                Convert.ToBase64String(imageFile, 0, imageFile.Length));
    }
}
