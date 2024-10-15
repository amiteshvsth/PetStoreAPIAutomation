using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace API_Automation.Utilities
{
#nullable disable
    public static class Extensions
    {
        // Shared settings for JSON serialization
        private static readonly JsonSerializerSettings _jsonSettings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        // Helper method to handle HTTP requests and responses
        private static async Task<TDto> SendRequestAsync<TDto>(
            HttpClient client,
            HttpMethod method,
            string requestUri,
            object ddto = null,
            bool isMultipart = false)
        {
            HttpContent httpContent = null;

            if (ddto != null)
            {
                if (isMultipart)
                {
                    // If it's multipart, assume it's already MultipartFormDataContent
                    if (ddto is MultipartFormDataContent multipartContent)
                    {
                        httpContent = multipartContent;
                    }
                }
                else
                {
                    // For JSON payloads
                    var json = JsonConvert.SerializeObject(ddto, _jsonSettings);
                    httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                }
            }

            var httpRequestMessage = new HttpRequestMessage(method, requestUri)
            {
                Content = httpContent
            };

            var httpResponse = await client.SendAsync(httpRequestMessage);
            httpResponse.EnsureSuccessStatusCode();
            var content = await httpResponse.Content.ReadAsStringAsync();
            var dto = JsonConvert.DeserializeObject<TDto>(content);

            return dto;
        }

        public static async Task<TDto> GetAsync<TDto>(this HttpClient client, string requestUri)
        {
            var httpResponse = await client.GetAsync(requestUri);
            httpResponse.EnsureSuccessStatusCode();
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TDto>(content);
        }

        public static async Task<TDto> PostAsync<TDto>(this HttpClient client, string requestUri, object ddto = null)
        {
            return await SendRequestAsync<TDto>(client, HttpMethod.Post, requestUri, ddto);
        }

        // Overload to handle multipart requests
        public static async Task<TDto> PostAsync<TDto>(this HttpClient client, string requestUri, object ddto = null, bool isMultipart = false)
        {
            return await SendRequestAsync<TDto>(client, HttpMethod.Post, requestUri, ddto, isMultipart);
        }

        public static async Task<TDto> PutAsync<TDto>(this HttpClient client, string requestUri, object ddto)
        {
            return await SendRequestAsync<TDto>(client, HttpMethod.Put, requestUri, ddto);
        }

        public static async Task<TDto> DeleteAsync<TDto>(this HttpClient client, string requestUri, object ddto = null)
        {
            return await SendRequestAsync<TDto>(client, HttpMethod.Delete, requestUri, ddto);
        }

        // Helper method to serialize an object to StringContent
        public static StringContent ToStringContent(this object dto)
        {
            var json = JsonConvert.SerializeObject(dto, _jsonSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
