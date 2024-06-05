using APITesting.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TestFrameworkCore.Helper;

namespace APITesting.Test
{
    [TestClass]
    public class UserAPITest
    {
        private RestClient client;

        [TestInitialize]
        public void TestInitalize()
        {
            var url = ConfiguationHelper.GetConfig<string>("url");
            client = new RestClient(url);
        }

        [TestMethod("TC05: Get List User")]
        public void VerifyGetListUser()
        {

            int randomPage = new Random().Next(1, 11);
            var request = new RestRequest($"/api/users?page={randomPage}", Method.Get);
            RestResponse response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            GetUserModel model = JsonConvert.DeserializeObject<GetUserModel>(response.Content);
            model.page.Should().Be(randomPage);
        }

        [TestMethod("TC06: Create New User")]
        public void VerifyCreateUser()
        {
            //create a new request.
            var request = new RestRequest("/api/users", Method.Post);
            //create Request model.
            var requestModel = new CreateUserRequestModel
            {
                Name = "Sang" + DateTime.Now.ToFileTimeUtc(),
                Job = "Automation Test",
            };
            //send data to api.
            request.AddJsonBody(requestModel);
            //get respone data.
            RestResponse response = client.Execute(request);

            // Assert status after creating.
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            //Change data res to json data.
            var responseModel = JsonConvert.DeserializeObject<CreateUserResponseModel>(response.Content);

            //Assertion.
            responseModel.name.Should().Be(requestModel.Name);
            responseModel.job.Should().Be(requestModel.Job);

        }
    }
}
