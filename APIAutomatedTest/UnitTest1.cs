using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace APIAutomatedTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RestClient restClient = new RestClient("https://postman-echo.com/stream/10");

            RestRequest restRequest = new RestRequest("", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            System.Console.WriteLine(response);

            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK, "Get request status is not ok");
        }

        [TestMethod]
        public void firstPost()
        {
                           
            RestClient restClient = new RestClient("https://postman-echo.com/post");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddParameter("application/json", "C://People.json", ParameterType.RequestBody);
            IRestResponse restResponse = restClient.Execute(restRequest);

            System.Console.WriteLine("Post response" + restResponse.Content);

           
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
