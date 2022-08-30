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

        [SetUp]
        public void Setup()
        {
            _client = Helper.SetClient();
            // arrange
            var request = Helper.CreateGetRequest("/v1/Categories/6327/Details.json?catalogue=false");
            // act
            _response = Helper.CreateGetResponse(_client, request);
            _dTORegistry = JsonConvert.DeserializeObject<Registry>(_response.Content);
        }

        [TestCase("Carbon credits", HttpStatusCode.OK, TestName = "Verify the name of the category")]
        [Test]
        public void VerifytheNameoftheCategory(string name, HttpStatusCode expectedHttpStatusCode)
        {   
            // assert
            Assert.That(_response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
            Assert.That(_dTORegistry.Name, Is.EqualTo(name));
        }

        [TestCase(true, HttpStatusCode.OK, TestName = "Verify category can re-list")]
        public void VerifyCategoryCanRelist(bool status, HttpStatusCode expectedHttpStatusCode)
        {
            // assert
            Assert.That(_response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
            Assert.That(_dTORegistry.CanRelist, Is.EqualTo(status));
        }

        [TestCase("Gallery", "Good position in category", HttpStatusCode.OK, TestName = "Verify the promotion name with description")]
        public void VerifyRegistryInfo(string name, string description, HttpStatusCode expectedHttpStatusCode)
        {
            // assert
            Assert.That(_response.StatusCode, Is.EqualTo(expectedHttpStatusCode));

            Assert.Multiple(() =>
            {
                var status = false;
                for (int i = 0; i < _dTORegistry.Promotions.Count; i++)
                {
                    if (name.Equals(_dTORegistry.Promotions[i].Name))
                    {
                        Assert.That(_dTORegistry.Promotions[i].Name, Is.EqualTo(name));
                        Assert.That(_dTORegistry.Promotions[i].Description, Is.EqualTo(description), "Description does not match with the given content");
                        status = true;
                        break;
                    }
                }
                if (!status)
                {
                    Assert.Fail("Category not listed in the registry");
                }
            });
        }

        [TearDown]
        public void Close()
        {
            Console.WriteLine("Verification points completed!");
        }
    }
}
