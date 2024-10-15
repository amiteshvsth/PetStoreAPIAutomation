using API_Automation.Dtos.Common;
using API_Automation.Dtos.Pet;

namespace API_Automation.DataFactory
{
    public class FindPetsByStatus
    {
        public static FindPetsByStatusRequest ValidData()
        {
            // Creating and returning the UpdateExistingPetRequest with the populated pet object
            return new FindPetsByStatusRequest
            {
                Status = [PetStatus.available,PetStatus.pending]
            };
        }
    }
}
