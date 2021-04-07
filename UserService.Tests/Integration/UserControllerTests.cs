using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using UserService.HostApi;
using Xunit;

namespace UserService.Tests.Integration
{
    public class UserControllerTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UserControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_EndpointReturnsSuccess()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("user");

            response.EnsureSuccessStatusCode();
        }
    }
}
