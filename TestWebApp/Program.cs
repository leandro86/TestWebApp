using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LightInject;
using LightInject.Microsoft.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
                .UseLightInject()
                
                .UseStartup<Startup>();
    }

    public interface IFoo
    {

    }

    public class Foo : IFoo
    {

    }

    //public class LightInjectServiceProviderFactory : IServiceProviderFactory<IServiceContainer>
    //{
    //    private IServiceCollection _services;
    //    private ServiceContainer _serviceContainer;

    //    public IServiceContainer CreateBuilder(IServiceCollection services)
    //    {
    //        _services = services;
    //        _serviceContainer = new ServiceContainer(new ContainerOptions { EnablePropertyInjection = false});
    //        return _serviceContainer;
    //    }

    //    public IServiceProvider CreateServiceProvider(IServiceContainer containerBuilder)
    //    {
    //        var provider = containerBuilder.CreateServiceProvider(_services);                      
    //        return provider;
    //    }
    //}

    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder UseLightInject(this IWebHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices(services => services.AddSingleton<IServiceProviderFactory<IServiceContainer>>(sp => new LightInjectServiceProviderFactory()));
        }
    }

    
}
