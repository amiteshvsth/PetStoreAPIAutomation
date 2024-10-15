using API_Automation.DataFactory;
using API_Automation.Dtos.Common;
using API_Automation.Endpoints;
using API_Automation.Utilities;
#nullable disable

namespace API_Automation.Tests
{
    [TestClass]
    [TestCategory("UserTests")]
    public class UserTests : BaseUri
    {

        [TestMethod]
        public async Task Post_VerifyThatWeCanCreateUserWithList()
        {
            var Client = await GetAuthenticatedClient();
            //arrange
            var request = CreateUsersWithList.ValidData();

            //act
            var response = Client.PostAsync<APIResponse>(UserEndPoints.CreateUserWithList(), request).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(CSharpHelpers.StatusCode, response.Code, "The Response Code does not match");
            Assert.AreEqual(CSharpHelpers.Type, response.Type, "Type does not match");
            Assert.AreEqual("ok", response.Message, "Message does not match");
        }

        [TestMethod]
        public async Task Get_VerifyThatWeCanGetUserWithUserName()
        {
            await Post_VerifyThatWeCanCreateUser();
            var Client = await GetAuthenticatedClient();
            //arrange
            var request = FindUserByUsername.ValidData();
            //act
            var response = Client.GetAsync<Users>(UserEndPoints.GetUserWithUserName(request.Username)).GetAwaiter().GetResult();

            //assert
            Assert.IsNotNull(response.Id,  "Id was null");
            Assert.AreEqual(request.Username, response.Username, "username does not match");
            Assert.IsNotNull( response.FirstName, "firstName was null");
            Assert.IsNotNull(response.LastName, "lastName was null");
            Assert.IsNotNull(response.Email, "email was null");
            Assert.IsNotNull(response.Password, "password was null");
            Assert.IsNotNull(response.Phone, "phone was null");
            Assert.IsNotNull(response.UserStatus, "userStatus was null");
        }

        [TestMethod]
        public async Task Put_VerifyThatWeCanUpdateUser()
        {
            var Client = await GetAuthenticatedClient();
            //arrange
            var request = UpdatedUser.ValidData();

            //act
            var response = Client.PutAsync<APIResponse>(UserEndPoints.UpdateUser(request.Username), request).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(CSharpHelpers.StatusCode, response.Code, "The Response Code does not match");
            Assert.AreEqual(CSharpHelpers.Type, response.Type, "Type does not match");
            Assert.AreEqual(request.Id.ToString(), response.Message, "The Response Message does not match");
        }

        [TestMethod]
        public async Task Delete_VerifyThatWeCanDeleteUser()
        {
            await Post_VerifyThatWeCanCreateUser();
            var Client = await GetAuthenticatedClient();
            //arrange
            var request = UpdatedUser.ValidData();
            //act
            var response = Client.DeleteAsync<APIResponse>(UserEndPoints.DeleteUser(request.Username)).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(CSharpHelpers.StatusCode, response.Code, "The Response Code does not match");
            Assert.AreEqual(CSharpHelpers.Type, response.Type, "Type does not match");
            Assert.AreEqual(request.Username, response.Message, "The Response Message does not match");
        }

        [TestMethod]
        public async Task Get_VerifyThatUserIsAbleToLoginSuccessfully()
        {
            var Client = await GetAuthenticatedClient();
            //arrange
            var request = LoginUser.ValidData();

            var formData = new Dictionary<string, string>
            {
                { "username", request.Username },
                { "password", request.Password }
            };

            // Create FormUrlEncodedContent
            var content = new FormUrlEncodedContent(formData);

            // Get the encoded query string (excluding the '?' at the start)
            string queryString = await content.ReadAsStringAsync();

            // Build the full URL with query parameters
            string requestUrl = $"{UserEndPoints.LoginUser()}?{queryString}";

            //act
            var response = Client.GetAsync<APIResponse>(requestUrl).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(CSharpHelpers.StatusCode, response.Code, "The Response Code does not match");
            Assert.AreEqual(CSharpHelpers.Type, response.Type, "Type does not match");
            Assert.IsTrue(response.Message.Contains("logged in user session"), "The Response Message does not match");
        }

        [TestMethod]
        public async Task Get_VerifyThatUserIsAbleToLogoutSuccessfully()
        {
            var Client = await GetAuthenticatedClient();
            //act
            var response = Client.GetAsync<APIResponse>(UserEndPoints.LogoutUser()).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(CSharpHelpers.StatusCode, response.Code, "The Response Code does not match");
            Assert.AreEqual(CSharpHelpers.Type, response.Type, "Type does not match");
            Assert.AreEqual("ok", response.Message, "The Response Message does not match");
        }

        [TestMethod]
        public async Task Post_VerifyThatWeCanCreateUserWithArray()
        {
            var Client = await GetAuthenticatedClient();
            //arrange
            var request = CreateUsersWithList.ValidData();

            //act
            var response = Client.PostAsync<APIResponse>(UserEndPoints.CreateUserWithArray(), request).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(CSharpHelpers.StatusCode, response.Code, "The Response Code does not match");
            Assert.AreEqual(CSharpHelpers.Type, response.Type, "Type does not match");
            Assert.AreEqual("ok", response.Message, "The Response Message does not match");
        }

        [TestMethod]
        public async Task Post_VerifyThatWeCanCreateUser()
        {
            var Client = await GetAuthenticatedClient();
            //arrange
            var request = CreateUsers.ValidData();
            //act
            var response = Client.PostAsync<APIResponse>(UserEndPoints.CreateUser(), request).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(CSharpHelpers.StatusCode, response.Code, "The Response Code does not match");
            Assert.AreEqual(CSharpHelpers.Type, response.Type, "Type does not match");
            Assert.AreEqual(request.Id.ToString(), response.Message, "The Response Message does not match");
        }
    }
}

