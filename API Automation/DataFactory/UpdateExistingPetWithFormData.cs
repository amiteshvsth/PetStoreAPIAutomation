using API_Automation.Dtos.Common;
using API_Automation.Dtos.Pet;

namespace API_Automation.DataFactory
{
    public class UpdateExistingPetWithFormData
    {
        public static UpdateExistingPetWithFormDataRequest ValidData()
        {
            return new UpdateExistingPetWithFormDataRequest
            {
                PetId = 12345,
                Name = "amitesh",
                Status = PetStatus.available,
            };
        }
    }
}
