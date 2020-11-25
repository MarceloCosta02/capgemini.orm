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
            // Adicionando o contexto via lambda expression via injeção de dependencia
            services.AddDbContext<PetShopContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Injeção de dependência dos Repository's
            services.AddScoped<IRepositoryEF, RepositoryEF>();
            services.AddScoped<IPetShopRepository, PetShopRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            // Injeção de dependência dos Business
            services.AddScoped<IPetBusiness, PetBusiness>();
            services.AddScoped<IPetShopBusiness, PetShopBusiness>();
            services.AddScoped<ICompanyBusiness, CompanyBusiness>();
            services.AddScoped<IClientBusiness, ClientBusiness>();

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
