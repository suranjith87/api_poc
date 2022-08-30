using API_POC.DTO;
using API_POC.Utility;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace API_POC
{
    [Binding]
    public class RegistryStepDefinitions
    {
        private Registry? _dTORegistry;
        private RestResponse _response;
        private RestClient _client;

        [Given(@"I have access the api end point of registry")]
        public void GivenIHaveAccessTheApiEndPointOfRegistry()
        {
            // arrange
            _client = Helper.SetClient();
            var request = Helper.CreateGetRequest("/v1/Categories/6327/Details.json?catalogue=false");
            // act
            _response = Helper.CreateGetResponse(_client, request);
        }

        [When(@"I access the details of catagory")]
        public void WhenIAccessTheDetailsOfCatagory()
        {
            _dTORegistry = JsonConvert.DeserializeObject<Registry>(_response.Content);
        }

        [Then(@"I should be able to catagory name as ""([^""]*)""")]
        public void ThenIShouldBeAbleToCatagoryNameAs(string name)
        {
            Assert.AreEqual(System.Net.HttpStatusCode.OK, _response.StatusCode);
            Assert.AreEqual(_dTORegistry.Name, name);
        }

        [Then(@"I should be able to view catagory re-list status as ""([^""]*)""")]
        public void ThenIShouldBeAbleToViewCatagoryRe_ListStatusAs(bool value)
        {
            Assert.AreEqual(_dTORegistry.CanRelist, value);
        }

        [Then(@"I should be able to view promotion name as ""([^""]*)"" has a Description that contains the text ""([^""]*)""")]
        public void ThenIShouldBeAbleToViewPromotionNameAsHasADescriptionThatContainsTheText(string name, string description)
        {
            var status = false;
            for (int i = 0; i < _dTORegistry.Promotions.Count; i++)
            {
                if (name.Equals(_dTORegistry.Promotions[i].Name))
                {
                    Assert.AreEqual(_dTORegistry.Promotions[i].Name, name);
                    Assert.AreEqual(_dTORegistry.Promotions[i].Description, description, "Description does not match with the given content");
                    status = true;
                    break;
                }
            }
            if (!status)
            {
                Assert.Fail("Category not listed in the registry");
            }
        }
    }
}
