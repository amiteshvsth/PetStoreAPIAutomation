using System.Drawing;
namespace API_Automation.Utilities
{
    public class CSharpHelpers
    {
        public static readonly int StatusCode = 200;
        public static readonly string Type = "unknown";
        public static string ImageToBase64(string imagePath)
        {
            //using var image = Image.FromFile(imagePath);
            //using var m = new MemoryStream();
            //image.Save(m, image.RawFormat);
            //var imageBytes = m.ToArray();
            //var base64String = Convert.ToBase64String(imageBytes);
            //return base64String;

            //old code
            //return "data:image/png;base64," + base64String;

            // more feasable way
            byte[] imageArray = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageArray);
        }
    }
}
