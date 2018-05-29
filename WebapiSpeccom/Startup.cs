using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpeccomDB.Models;
using SpeccomInterface;
using WebapiSpeccom.Controllers;

namespace WebapiSpeccom
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
            services.AddMvc();
            //var connection = @"Server=(local);user=knight;password=1234;Database=speccom;Trusted_Connection=True;ConnectRetryCount=0";
            var connection = Configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<speccomContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IUser, UserServices > ();
            services.AddScoped<IComputer, ComputerService>();
            services.AddScoped<IComputerUser, ComputerUserServices>();
            services.AddScoped<IMemory, MemoryService>();
            services.AddScoped<IDiskDrive, DiskDriveService>();
            services.AddScoped<IGraphicCards, GraphicCardsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors(builder =>
            //builder.WithOrigins("*").AllowAnyHeader());
            app.UseCors(builder => builder
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());

            app.UseMvc();
        }
    }
}
