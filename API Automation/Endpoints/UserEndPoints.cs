namespace API_Automation.Endpoints
{
    public class UserEndPoints
    {
        public static string CreateUserWithList() => "user/createWithList";
        public static string GetUserWithUserName(string username) => $"user/{username}";
        public static string UpdateUser(string username) => $"user/{username}";
        public static string DeleteUser(string username) => $"user/{username}";
        //public static string LoginUser(string username,string password) => $"user/login?username={username}&password={password}";
        public static string LoginUser() => $"user/login";
        public static string CreateUser() => "user";
        public static string LogoutUser() => "user/logout";
        public static string CreateUserWithArray() => "user/createWithArray";

    }
}
