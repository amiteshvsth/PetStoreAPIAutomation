using API_Automation.Dtos;
using API_Automation.Dtos.Store;
using API_Automation.Dtos.User;

namespace API_Automation.DataFactory
{
    public class LoginUser
    {
        public static LoginUserRequest ValidData()
        {
            // Creating and returning the UpdateExistingPetRequest with the populated pet object
            return new LoginUserRequest
            {
                Username = "amitesh",
                Password = "amitesh",
            };
        }
    }
}
