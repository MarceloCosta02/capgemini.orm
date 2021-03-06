using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiorm.Business.Implementations;
using apiorm.Business.Interfaces;
using apiorm.Models;
using apiorm.Repository.Context;
using apiorm.Repository.Implementations;
using apiorm.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace apiorm
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adicionando o contexto via lambda expression via inje��o de dependencia
            services.AddDbContext<PetShopContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Inje��o de depend�ncia dos Repository's
            services.AddScoped<IRepositoryEF, RepositoryEF>();
            services.AddScoped<IPetShopRepository, PetShopRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            // Inje��o de depend�ncia dos Business
            services.AddScoped<IPetBusiness, PetBusiness>();
            services.AddScoped<IPetShopBusiness, PetShopBusiness>();
            services.AddScoped<ICompanyBusiness, CompanyBusiness>();
            services.AddScoped<IClientBusiness, ClientBusiness>();

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "PetShop API's with ASP NET Core 3.1",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
