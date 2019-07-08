﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ProductDbContext>();
            services.AddSingleton<ProductRepository>();
        }

        public void Configure(IApplicationBuilder app, ProductDbContext productDbContext)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvc();
            productDbContext.Seed();
        }
    }
}
