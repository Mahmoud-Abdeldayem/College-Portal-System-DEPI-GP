using Microsoft.EntityFrameworkCore;

namespace College_portal_System.Utilities
{
    public static class ImageHandler
    {
        public static byte[] ChangeIFormImageToBinary(IFormFile image)
        {
            byte[] binaryImage;
            using (var memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                binaryImage = memoryStream.ToArray();
            }
            return binaryImage;
        }

        public static string GetBase64Image(byte[] image)
        {
             if(image == null)
            {
                return null;
            }
            return Convert.ToBase64String(image);
        }

        public static string GetImageSouce(string image)
        {
            return $"data:image/jpeg;base64,{image}";
        }
    }
}
