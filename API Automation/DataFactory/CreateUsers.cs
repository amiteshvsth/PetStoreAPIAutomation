using API_Automation.Dtos.Common;

namespace API_Automation.DataFactory
{
    public class CreateUsers
    {
        public static Users ValidData()
        {
            return new Users
            {
                Id = 1,
                Username = "testUser",
                FirstName = "Amitesh",
                LastName = "Amitesh",
                Email = "Amitesh",
                Password = "Amitesh",
                Phone = "Amitesh",
                UserStatus = 1
            };
        }
    }


}
