using API_Automation.Dtos.Pet;

namespace API_Automation.DataFactory
{
    public class FindPetById
    {
        public static FindPetByIdRequest ValidData()
        {
            // Creating and returning the UpdateExistingPetRequest with the populated pet object
            return new FindPetByIdRequest
            {
                PetId = 12345,
            };
        }
    }
}
