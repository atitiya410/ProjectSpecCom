using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeccomDB.Models;
using SpeccomInterface;
using Microsoft.Extensions.Logging;

namespace XUnitTestSpeccom

{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<speccomContext>(optionsBuilder => optionsBuilder.UseInMemoryDatabase("InMemoryDb"));
            services.AddMvc();

            services.AddScoped<IUser, UserServices>();
            services.AddScoped<IComputer, ComputerService>();
            services.AddScoped<IComputerUser, ComputerUserServices>();
            services.AddScoped<IMemory, MemoryService>();
            services.AddScoped<IDiskDrive, DiskDriveService>();
            services.AddScoped<IGraphicCards, GraphicCardsService>();
        }


        //public void Configure(IApplicationBuilder app,
        //    IHostingEnvironment env,
        //    ILoggerFactory loggerFactory)
        //{
        //    var repository = app.ApplicationServices.GetService<IUser>();
        //    InitializeDatabaseAsync(repository);

        //    app.UseStaticFiles();

        //    app.UseMvcWithDefaultRoute();
        //}

        //IUser
        //public void InitializeDatabaseAsync(IUser repo)
        //{
        //    var sessionList = repo.GetAllUsers();
        //    if (!sessionList.Any())
        //    {
        //        repo.AddUser(gettestsession(1));

               
        //    }
        //}

        public static User gettestsession(int id)
        {
            var session = new User
            {
                UserId = id,
                UserName = $"user {id}",
               
            };

            return session;
        }

        // IComputerTest
        public void InitializeDatabaseAsync(IComputer repo)
        {
            var sessionList = repo.GetAllComputers();
            if (!sessionList.Any())
            {
                repo.AddComputer(gettestsession("AAA"));

            }
        }

        public static Computer gettestsession(string com)
        {
            DateTime dateTime = new DateTime();
            var session = new Computer
            {
                ProcessorId = com,
                Cpuname = $"computer {com}",
                Cores = 1,
                Thread = 1,
                LastUpdate = dateTime

            };

            return session;
        }


    }
}