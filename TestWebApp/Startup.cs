using System.Collections.Generic;
using LightInject;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using TestWebApp.Mapping.Resolvers;
using System;
using System.Diagnostics;
using LightInject.Microsoft.DependencyInjection;
using System.Linq;
using TestWebApp.Controllers;
using Microsoft.AspNetCore.Mvc.Internal;

namespace TestWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()/*.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)*/;
            services.AddSingleton<IEnumerable<IFoo>>(sp => new[] { new Foo() });

            services.AddSingleton<LocalizedDescriptionResolver>();
            services.AddAutoMapper();

            var serviceContainer = new ServiceContainer(new ContainerOptions
            {
                EnablePropertyInjection = false,
                //LogFactory = type => logEntry => Debug.WriteLine(logEntry.Message),
                DefaultServiceSelector = s => s.Last(),
                EnableVariance = false
            })
            {
                ScopeManagerProvider = new PerLogicalCallContextScopeManagerProvider()
            };



            //serviceContainer.GetInstance<MvcRouteHandler>();

            //return services.BuildServiceProvider();
            var lightInjectServiceProvider = serviceContainer.CreateServiceProvider(services);
            return lightInjectServiceProvider;
        }

        //public void ConfigureContainer(IServiceContainer container)
        //{

        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
