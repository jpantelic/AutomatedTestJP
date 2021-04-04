using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.IO;
using System.Net;
using Assert = NUnit.Framework.Assert;

namespace APIAutomatedTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetFromStream()
        {
            RestClient restClient = new RestClient("https://postman-echo.com/");

            RestRequest restRequest = new RestRequest("stream/10", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            System.Console.WriteLine(response);

            JObject obs = JObject.Parse(restResponse.Content);
            Assert.That(obs["host"].ToString, Is.EqualTo("postman-echo.com"), "Host parameter is not correct");

            //Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK, "Get request status is not ok");
        }

        [TestMethod]
        public void PostFromJsonFile()
        {
                           
            var client = new RestClient("https://postman-echo.com/");
            var request = new RestRequest("post", Method.POST);
            request.RequestFormat = DataFormat.Json;            
            var file = @"TestData\People.json";

            var jsonData = JsonConvert.DeserializeObject<Person>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file)).ToString());
            request.AddJsonBody(jsonData);            
            var response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, "Post response is not ok");
        }

        private class Person
        {
            public string name { get; set; }
            public string lastName { get; set; }
            public string occupation { get; set; }
            public string age { get; set; }
            public string region { get; set; }
    }

        [TestMethod]
        public void firstAuthenticators()
        {
            RestClient restClient = new RestClient("https://postman-echo.com/basic-auth");
            restClient.Authenticator = new HttpBasicAuthenticator("postman", "password");

            RestRequest restRequest = new RestRequest("", Method.GET);
            IRestResponse restResponse = restClient.Execute(restRequest);

            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK, "Get request status, or username/password is/are not ok");

        }
    }
}
