using API_Automation.Dtos.Pet;

namespace API_Automation.DataFactory
{
    public class FindUserByUsername
    {
        public static FindUserByUsernameRequest ValidData()
        {
            // Creating and returning the UpdateExistingPetRequest with the populated pet object
            return new FindUserByUsernameRequest
            {
                Username = "testUser",
            };
        }
    }
}
