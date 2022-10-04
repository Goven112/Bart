using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.BLL;
using WebApplication1.BLL.AccountService;
using WebApplication1.BLL.ContactService;
using WebApplication1.Interfaces;
using WebApplication1.Mapper;
using WebApplication1.Model;

namespace WebApplication1
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

            services.AddControllers();

            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=DBJOB;Trusted_Connection=True;";

            services.AddDbContext<TaskDbContext>(options => options.UseSqlServer(connectionString));
         
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIncidentService, IncidentService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IAccountService, AccountService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
           
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
