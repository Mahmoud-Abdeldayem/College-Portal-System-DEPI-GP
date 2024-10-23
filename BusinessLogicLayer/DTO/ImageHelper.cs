using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class ImageHelper
    {
        public static string GetBase64Image(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
                throw new ArgumentException("Image bytes cannot be null or empty.");

            // Convert the byte array to a Base64 string
            return Convert.ToBase64String(imageBytes);
        }
    }
}
