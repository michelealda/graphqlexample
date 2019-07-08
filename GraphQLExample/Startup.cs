using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQLExample.GraphQL;
using GraphQLExample.Infrastructure;
using Microsoft.AspNetCore.Builder;
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
            services.AddDbContext<ProductDbContext>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductReviewRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddScoped<ProductSchema>();

            services.AddGraphQL(o =>
                {
                    o.ExposeExceptions = true;
                    o.EnableMetrics = true;
                })
                .AddGraphTypes(ServiceLifetime.Scoped);
        }

        public void Configure(IApplicationBuilder app, ProductDbContext productDbContext)
        {
            app.UseGraphQL<ProductSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            productDbContext.Seed();
        }
    }
}
