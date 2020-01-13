using EmpregosDevHiringAPI.Extensions;
using EmpregosDevHiringAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmpregosDevHiringAPI.External
{
    public class HttpWrapper
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpWrapper(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Response<T>> Get<T>(string url)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var client = _clientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("User-Agent", "EmpregosDevHiringTest");
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<T>
                    {
                        Successful = false,
                        Errors = new[] { responseContent },
                        StatusCode = (int)response.StatusCode
                    };
                }

                var contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = contractResolver
                };

                var deserializedContent = JsonConvert.DeserializeObject<T>(responseContent, jsonSerializerSettings);
                return new Response<T>
                {
                    Content = deserializedContent,
                    StatusCode = (int)response.StatusCode,
                    Successful = true
                };
            }
            catch (Exception e)
            {
                return new Response<T>
                {
                    Errors = e.GetExceptionMessages(),
                    StatusCode = 0,
                    Successful = false
                };
            }
        }
    }
}
