using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using LightInject;


namespace TestWebApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            IWebHostBuilder builder = new WebHostBuilder()
            .ConfigureTestServices(services => services.AddSingleton<IFoo, MockFoo>())
            .UseLightInject()
            .UseStartup<Startup>();                        

            using (var testServer = new TestServer(builder))
            {
                var client = testServer.CreateClient();
                var response = await client.GetAsync("api/values");
                response.EnsureSuccessStatusCode();
            }
        }
    }

    public class MockFoo : IFoo
    {

    }
}
