using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_POC.Utility
{
    public static class Helper
    {
        public static RestClient _restClient;
        public static RestRequest _restRequest;
        public static string _baseUrl = TestContext.Parameters["BaseURL"];

        public static RestClient SetClient()
        {
            _restClient = new RestClient(_baseUrl);
            return _restClient;
        }

        public static RestRequest CreateGetRequest(string endpoint)
        {
            _restRequest = new RestRequest(endpoint)
            {
                Method = Method.Get
            };

            _restRequest.AddHeaders(new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" }
            });

            return _restRequest;
        }

        public static RestResponse CreateGetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }
    }
}
