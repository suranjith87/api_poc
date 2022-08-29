using API_POC.DTO;
using API_POC.Utility;
using Newtonsoft.Json;
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
        private Registry? _dTORegistry;

        [Test]
        public void VerifytheNameoftheCategory()
        {
            _client = Helper.SetClient();
            // arrange
            _request = Helper.CreateGetRequest("/v1/Categories/6327/Details.json?catalogue=false");
            // act
            _response = Helper.CreateGetResponse(_client, _request);
            _dTORegistry = JsonConvert.DeserializeObject<Registry>(_response.Content);
            // Assert
            Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(_dTORegistry.Name, Is.EqualTo("Carbon credits"));
            Assert.That(_dTORegistry.CanRelist, Is.EqualTo(true));
        }
    }
}
