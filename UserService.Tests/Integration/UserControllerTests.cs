using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Dtos;
using UserService.HostApi;
using Xunit;

namespace UserService.Tests.Integration
{
    public class UserControllerTests
        : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public UserControllerTests(
            CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        public IEnumerable<HttpStatusCode> ExpectedStatuses = new List<HttpStatusCode> { HttpStatusCode.NoContent, HttpStatusCode.Created, HttpStatusCode.OK };

        [Fact]
        public async Task Get_EndpointReturnsSuccess()
        {
            var response = await _client.GetAsync("api/user");

            response.EnsureSuccessStatusCode();

            Assert.Contains(response.StatusCode, ExpectedStatuses);
        }

        [Fact]
        public async Task GetById_EndpointReturnsSuccess()
        {
            var response = await _client.GetAsync("api/user/1");

            response.EnsureSuccessStatusCode();

            Assert.Contains(response.StatusCode, ExpectedStatuses);
        }

        [Fact]
        public async Task Post_InsertNewUser()
        {
            var userDto = new UserDto { Name = "Test", Birthdate = new DateTime(1982, 07, 16) };
            var stringContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/user", stringContent);

            response.EnsureSuccessStatusCode();
            Assert.Contains(response.StatusCode, ExpectedStatuses);
        }

        [Fact]
        public async Task Delete_RemovesUser()
        {
            var response = await _client.DeleteAsync("api/user/1");

            response.EnsureSuccessStatusCode();
            Assert.Contains(response.StatusCode, ExpectedStatuses);
        }
    }
}
