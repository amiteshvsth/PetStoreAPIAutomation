using API_Automation.Dtos.Pet;
using API_Automation.Utilities;
namespace API_Automation.DataFactory
{
    public class UploadImage
    {
        public static UploadAnImageRequest ValidData()
        {
            return new UploadAnImageRequest
            {
                PetId = 1,
                AdditionalMetadata = "Amitesh",
                File = CSharpHelpers.ImageToBase64("C:/Users/amitesh/source/repos/API Automation/API Automation/DataFactory/krishna.png")
            };
        }

        
    }
}
