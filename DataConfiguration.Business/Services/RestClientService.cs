using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataConfiguration.Business.Services
{
    public class RestClientService : IRestClientService
    {
        public async Task Execute(Uri endpoindUrl, string method, string data = null)
        {
            try
            {
                var client = new RestClient(endpoindUrl);
                var request = new RestRequest();
                var httpMethod = new HttpMethod(method);

                if (string.CompareOrdinal(httpMethod.Method?.ToLower(), "post") == 0)
                {
                    request.Method = Method.POST;
                    var response = await client.ExecuteAsync(request);

                    if (!response.IsSuccessful) throw new HttpRequestException("rest request failed!");
                }
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
    }
}
