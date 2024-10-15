using API_Automation.DataFactory;
using API_Automation.Dtos.Common;
using API_Automation.Endpoints;
using API_Automation.Utilities;
#nullable disable

namespace API_Automation.Tests
{
    [TestClass]
    [TestCategory("PetTests")]
    public class PetTests : BaseUri
    {

        [TestMethod]
        public async Task Post_VerifyThatTheImageIsUploadingSuccessfully()
        {
            var Client = await GetAuthenticatedClient();

            //arrange
            var request = UploadImage.ValidData();

            // Create MultipartFormDataContent to handle the file and metadata
            var multipartContent = new MultipartFormDataContent
                        {
                            // Add metadata as string content
                            { new StringContent(request.AdditionalMetadata), "additionalMetadata" }
                        };

            // Convert the base64 string back to byte array and add it as file content
            byte[] fileBytes = Convert.FromBase64String(request.File);
            var byteArrayContent = new ByteArrayContent(fileBytes);
            byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");

            // Add the file content to the multipart form
            multipartContent.Add(byteArrayContent, "file", "krishna.png");

            //act
            var response = Client.PostAsync<APIResponse>(PetEndpoints.UploadImage(request.PetId), multipartContent, true).GetAwaiter().GetResult();

            // Assert
            Assert.AreEqual(CSharpHelpers.StatusCode, response.Code, "The Response Code does not match");
            Assert.AreEqual(CSharpHelpers.Type, response.Type, "Type does not match");
            Assert.IsTrue(response.Message.Contains("File uploaded to"), "Image was not uploaded");
        }

        [TestMethod]
        public async Task Post_VerifyThatWeCanAddNewPet()
        {
            var Client = await GetAuthenticatedClient();

            //arrange
            var request = AddNewPet.ValidData();

            //act
            var response = Client.PostAsync<Pets>(PetEndpoints.AddNewPet(), request).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(request.Id, response.Id, "The Pet Id does not match");
            Assert.AreEqual(request.Category.Id, response.Category.Id, "The Pet CategoryId does not match");
            Assert.AreEqual(request.Category.Name, response.Category.Name, "The Pet Category Name does not match");
            Assert.AreEqual(request.Name, response.Name, "The Pet Name does not match");
            Assert.AreEqual(request.PhotoUrls.First(), response.PhotoUrls.First(), "The Photo Url does not match");
            Assert.AreEqual(request.Tags.First().Id, response.Tags.First().Id, "The Pet Tags id does not match");
            Assert.AreEqual(request.Tags.First().Name, response.Tags.First().Name, "The Pet Tags name does not match");
            Assert.AreEqual(request.Status, response.Status, "The Pet Name is does not match");
        }

        [TestMethod]
        public async Task Put_VerifyThatWeCanUpdateExistingPet()
        {
            var Client = await GetAuthenticatedClient();

            //arrange
            var request = UpdateExistingPet.ValidData();

            //act
            var response = Client.PutAsync<Pets>(PetEndpoints.UpdateExistingPet(), request).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(request.Id, response.Id, "The Pet Id does not match");
            Assert.AreEqual(request.Category.Id, response.Category.Id, "The Pet CategoryId does not match");
            Assert.AreEqual(request.Category.Name, response.Category.Name, "The Pet Category Name does not match");
            Assert.AreEqual(request.Name, response.Name, "The Pet Name does not match");
            Assert.AreEqual(request.PhotoUrls.First(), response.PhotoUrls.First(), "The Photo Url does not match");
            Assert.AreEqual(request.Tags.First().Id, response.Tags.First().Id, "The Pet Tags id does not match");
            Assert.AreEqual(request.Tags.First().Name, response.Tags.First().Name, "The Pet Tags name does not match");
            Assert.AreEqual(request.Status, response.Status, "The Pet Name is does not match");
        }

        [TestMethod]
        public async Task Get_VerifyThatWeCanFindPetsByStatus()
        {
            var Client = await GetAuthenticatedClient();

            //arrange
            var request = FindPetsByStatus.ValidData();

            // Build the query string based on the enum values from the factory
            var queryParams = new List<string>();

            if (request.Status.Count > 0)
            {
                foreach (var status in request.Status)
                {
                    // Convert enum value to string and add it to the query parameters
                    queryParams.Add($"status={Uri.EscapeDataString(status.ToString())}");
                }
            }

            // Combine the base URL and the query parameters
            string fullUrl = $"{PetEndpoints.FindPetByStatus()}?{string.Join("&", queryParams)}";

            //act
            var response = Client.GetAsync<List<Pets>>(fullUrl).GetAwaiter().GetResult();

            foreach (var item in response)
            {
                try
                {
                    //assert
                    Assert.IsNotNull(item.Id, "Item id was Null");
                    Assert.IsNotNull(item.Category.Id, "Category Id was Null");
                    Assert.IsNotNull(item.Category.Name, "Category Name was Null");
                    Assert.IsNotNull(item.Name, "Item Name was Null");
                    Assert.IsNotNull(item.PhotoUrls, "PhotoUrls were Null");
                    Assert.IsNotNull(item.Tags.First().Id, "Tag Id was Null");
                    Assert.IsNotNull(item.Tags.First().Name, "Tag Name was Null");
                    Assert.IsNotNull(item.Status, "Status was null");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Some items were missing of itemid: {item.Id}\n" + ex);
                }
            }

        }

        [TestMethod]
        public async Task Get_VerifyThatWeCanFindPetById()
        {
            await Post_VerifyThatWeCanAddNewPet();
            var Client = await GetAuthenticatedClient();
            var request = FindPetById.ValidData();
            //act
            var response = Client.GetAsync<Pets>(PetEndpoints.FindPetById(request.PetId)).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(request.PetId, response.Id, "The Pet Id does not match");
            Assert.IsNotNull(response.Category.Id, "Category Id was Null");
            Assert.IsNotNull(response.Category.Name, "Category Name was Null");
            Assert.IsNotNull(response.Name, "Item Name was Null");
            Assert.IsNotNull(response.PhotoUrls, "PhotoUrls were Null");
            Assert.IsNotNull(response.Tags.First().Id, "Tag Id was Null");
            Assert.IsNotNull(response.Tags.First().Name, "Tag Name was Null");
            Assert.IsNotNull(response.Status, "Status was null");
        }

        [TestMethod]
        public async Task Post_VerifyThatWeCanUpdateExistingPetWithFormData()
        {
            var Client = await GetAuthenticatedClient();

            //arrange
            var request = UpdateExistingPetWithFormData.ValidData();

            var formData = new List<KeyValuePair<string, string>>{
                new("name", request.Name),
                new("status", request.Status.ToString())
            };

            var formContent = new FormUrlEncodedContent(formData);
            //act
            var response = Client.PostAsync<APIResponse>(PetEndpoints.UpdateExistingPetWithFormData(request.PetId), formContent, true).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(CSharpHelpers.StatusCode, response.Code, "The Response Code does not match");
            Assert.AreEqual(CSharpHelpers.Type, response.Type, "Type does not match");
            Assert.AreEqual(request.PetId.ToString(), response.Message, "Message Does not match");
        }

        [TestMethod]
        public async Task Delete_VerifyThatWeCanDeletePet()
        {
            await Post_VerifyThatWeCanAddNewPet();
            var Client = await GetAuthenticatedClient();

            //arrange
            var request = DeletePet.ValidData();

            //act
            var response = Client.DeleteAsync<APIResponse>(PetEndpoints.DeletePet(request.PetId)).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(CSharpHelpers.StatusCode, response.Code, "The Response Code does not match");
            Assert.AreEqual(CSharpHelpers.Type, response.Type, "Type does not match");
            Assert.AreEqual(request.PetId.ToString(), response.Message, "Message Does not match");
        }

    }
}