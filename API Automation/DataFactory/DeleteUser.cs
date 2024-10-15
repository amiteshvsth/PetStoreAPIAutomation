using API_Automation.Dtos.Pet;

namespace API_Automation.DataFactory
{
    public class DeleteUser
    {
        public static UsernameClass ValidData()
        {
           
            return new UsernameClass
            {
                Username = "testUser",
            };
        }
    }

    public class UsernameClass
    {
        public required string Username { get; set; }
    }
}
