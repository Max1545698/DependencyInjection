using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Routing;

namespace DependencyInjection
{
    public class Startup
    {
        private IHostingEnvironment env;
        public Startup(IHostingEnvironment hostEnv)
        {
            env = hostEnv;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IRepository>(provider =>
            //{
            //    if (env.IsDevelopment())
            //    {
            //        var x = provider.GetService<MemoryRepository>();
            //        return x;
            //    }
            //    else
            //    {
            //        return new AlternateRepository();
            //    }
            //});
            //TypeBroker.SetRepositoryType<AlternateRepository>();
            //services.AddTransient<MemoryRepository>();
            //services.AddScoped<IRepository, MemoryRepository>();
            services.AddSingleton<IRepository, MemoryRepository>();
            services.AddTransient<IModelStorage, DictionaryStorage>();
            services.AddTransient<ProductTotilizer>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
        }
    }
}
