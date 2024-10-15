using API_Automation.Dtos.Common;
using API_Automation.Dtos.Pet;

namespace API_Automation.DataFactory
{
    public class UpdatedUser
    {
        public static Users ValidData()
        {
            return new Users
            {
              Id = 1,
              Username = "testUser",
              FirstName = "test",
              LastName = "test",
              Email = "test",
              Password = "test",
              Phone = "test",
              UserStatus = 1
            };
        }
    }
}
