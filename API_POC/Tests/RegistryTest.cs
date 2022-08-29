using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API_POC.Tests
{
    public class RegistryTest
    {
        private RestClient _client;
        private RestRequest _request;
        private RestResponse _response;

        [Test]
        public void VerifytheNameoftheCategory()
        {
            var options = new RestClientOptions("https://api.tmsandbox.co.nz")
            {
                ThrowOnAnyError = true,
                MaxTimeout = 1000
            };
            _client = new RestClient(options);
            _request = new RestRequest("/v1/Categories/6327/Details.json?catalogue=fals",Method.Get);
            _response = _client.Execute(_request);
            Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
