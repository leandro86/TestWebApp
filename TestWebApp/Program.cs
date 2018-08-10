using LightInject;
using LightInject.Microsoft.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {           
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)                
                .UseStartup<Startup>();
    }

    public interface IFoo
    {

    }

    public class Foo : IFoo
    {

    }
   
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder UseLightInject(this IWebHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices(services => services.AddSingleton<IServiceProviderFactory<IServiceContainer>>(sp => new LightInjectServiceProviderFactory()));
        }
    }

    
}
