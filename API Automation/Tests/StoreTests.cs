using API_Automation.DataFactory;
using API_Automation.Dtos.Common;
using API_Automation.Endpoints;
using API_Automation.Utilities;
#nullable disable

namespace API_Automation.Tests
{
    [TestClass]
    [TestCategory("StoreTests")]
    public class StoreTests : BaseUri
    {

        [TestMethod]
        public async Task Get_VerifyThatWeCanGetPetInventoryByStatus()
        {
            var Client = await GetAuthenticatedClient();
            //act
            var response = Client.GetAsync<Inventory>(StoreEndPoints.GetPetInventoryByStatus()).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(0, response.AdditionalProp1, "Additional Prop 1 does not match");
            Assert.AreEqual(0, response.AdditionalProp2,  "Additional Prop 2 does not match");
            Assert.AreEqual(0, response.AdditionalProp3,  "Additional Prop 3 does not match");

        }

        [TestMethod]
        public async Task Post_VerifyThatWeCanPlaceOrderOfPet()
        {
            var Client = await GetAuthenticatedClient();
            //arrange
            var request = PlaceOrderPet.ValidData();

            //act
            var response = Client.PostAsync<Order>(StoreEndPoints.PlaceOrderPet(), request).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(request.Id, response.Id,  "Id does not match");
            Assert.AreEqual(request.PetId, response.PetId,  "petId does not match");
            Assert.AreEqual(request.Quantity, response.Quantity, "Quantity does not match");
            Assert.AreEqual(request.Status, response.Status,  "Status does not match");
            Assert.AreEqual(request.Complete, response.Complete, "Complete does not match");
        }

        [TestMethod]
        public async Task Get_VerifyThatWeCanFindPurchaseOrderById()
        {
            await Post_VerifyThatWeCanPlaceOrderOfPet();
            var Client = await GetAuthenticatedClient();

            //arrange

            var request = FindPurchaseOrderById.ValidData();
            //act
            var response = Client.GetAsync<Order>(StoreEndPoints.FindPurchaseOrderById(request.Id)).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(request.Id, response.Id,  "Id does not match");
            Assert.IsNotNull(response.PetId, "petId was null");
            Assert.IsNotNull(response.Quantity, "Quantity was null");
            Assert.IsNotNull(response.Status, "Status was null");
            Assert.IsNotNull(response.Complete, "Complete was null");
        }

        [TestMethod]
        public async Task Delete_VerifyThatWeCanDeletePurchaseOrderById()
        {
            await Post_VerifyThatWeCanPlaceOrderOfPet();
            var Client = await GetAuthenticatedClient();
            //arrange
            var request = DeletePurchaseOrderById.ValidData();
            //act
            var response = Client.DeleteAsync<APIResponse>(StoreEndPoints.DeletePurchaseOrderById(request.Id)).GetAwaiter().GetResult();

            //assert
            Assert.AreEqual(CSharpHelpers.StatusCode, response.Code, "The Response Code does not match");
            Assert.AreEqual(CSharpHelpers.Type, response.Type, "Type does not match");
            Assert.AreEqual(request.Id.ToString(), response.Message,  "The Response does not match");
        }

    }
}

