using System.Net.Http.Headers;

namespace API_Automation.Tests
{
    public class BaseUri
    {
        private const string BaseV1Uri = "https://petstore.swagger.io/v2/";
        public static async Task<HttpClient> GetAuthenticatedClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(string.Format(BaseV1Uri))

            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("api_key", "special-key");

            // Simulate a non-blocking asynchronous operation
            await Task.Delay(100); // Example of an async operation

            return client;
        }
    }
}