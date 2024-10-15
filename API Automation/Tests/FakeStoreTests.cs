using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace API_Automation.Tests
{
    [TestClass]
    [TestCategory("FakeStoreTests")]
    public class FakeStoreTests
    {
        private readonly string uri = "https://fakestoreapi.com/products/1";

        [TestMethod]
        public void DeleteProductDetails()
        {

            HttpClient httpclient = new();

            Task<HttpResponseMessage> httpResponse = httpclient.DeleteAsync(uri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            httpResponseMessage.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, httpResponseMessage.StatusCode, "Response Status Code does not match");

            httpclient.Dispose();
        }

        [TestMethod]
        public async Task AddProductDetails()
        {
            using HttpClient httpClient = new();
            var uri = "https://fakestoreapi.com/products";
            var productDetails = new
            {
                title = "test product",
                price = 100,
                description = "lorem ipsum set",
                image = "https://i.pravatar.cc",
                category = "electronic"
            };
            var productDetailsJson = JsonConvert.SerializeObject(productDetails);

            // body of the request here payload is a object of String Content Class and not a string
            var payload = new StringContent(productDetailsJson, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(uri, payload);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(responseBody);

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.IsNotNull(product, "Product details are null");
                Assert.IsNotNull(product.Id, "product id is null");
                Assert.AreEqual("test product", product.Title, "Product title isn't matched");
                Assert.AreEqual(100, product.Price, "Product price isn't matched");
                Assert.AreEqual("lorem ipsum set", product.Description, "Product description isn't matched");
                Assert.AreEqual("https://i.pravatar.cc", product.Image, "Product image isn't matched");
                Assert.AreEqual("electronic", product.Category, "Product category isn't matched");
            }
            catch (HttpRequestException ex)
            {
                Assert.Fail($"HTTP request failed: {ex.Message}");
            }
        }

        [TestMethod]

        public void GetProductDetails()
        {

            //Create the instance of an HttpClient

            HttpClient httpclient = new();

            //Create the request and execute it

            Task<HttpResponseMessage> httpResponse = httpclient.GetAsync(uri);

            HttpResponseMessage httpResponseMessage = httpResponse.Result;

            httpResponseMessage.Content.ReadAsStringAsync();

            //Assert the data
            Assert.AreEqual(HttpStatusCode.OK, httpResponseMessage.StatusCode, "Response Status Code does not match");

            //Close the connection
            httpclient.Dispose();
        }

        [TestMethod]
        public void UpdateProductDetails()
        {
            HttpClient httpClient = new();
            var uri = "https://fakestoreapi.com/products/1";
            var updateproductdetails = new Product()
            {
                Title = "Test update product",
                Price = 13,
                Description = "This is for test updation",
                Image = "https://i.pravatar.cc",
                Category = "electronic"
            };
            var productdetailsJson = JsonConvert.SerializeObject(updateproductdetails);
            var payload = new StringContent(productdetailsJson, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> httpResponse = httpClient.PutAsync(uri, payload);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponseMessage.StatusCode, "Response statuscode doesn't matched");
            Assert.IsNotNull(httpResponseMessage.Content);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required double Price { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required string Category { get; set; }
    }
}
