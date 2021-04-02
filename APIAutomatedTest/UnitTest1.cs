using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

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
        }
    }
}
