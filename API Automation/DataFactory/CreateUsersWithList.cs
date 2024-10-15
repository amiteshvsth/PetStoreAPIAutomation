using API_Automation.Dtos.Common;

namespace API_Automation.DataFactory
{
    public class CreateUsersWithList
    {
        public static List<Users> ValidData()
        {
            var user1 = new Users
            {
                Id = 1,
                Username = "Amitesh",
                FirstName = "Amitesh",
                LastName = "Amitesh",
                Email = "Amitesh",
                Password = "Amitesh",
                Phone = "Amitesh",
                UserStatus = 1
            };
            var user2 = new Users
            {
                Id = 2,
                Username = "Kamlesh",
                FirstName = "Kamlesh",
                LastName = "Kamlesh",
                Email = "Kamlesh",
                Password = "Kamlesh",
                Phone = "Kamlesh",
                UserStatus = 1
            };
            return
            [

                user1,
                user2
            ];
        }
    }


}
