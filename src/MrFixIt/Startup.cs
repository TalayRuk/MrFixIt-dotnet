using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MrFixIt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MrFixIt
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            //build a configurationfile appsettings.json to add path to connect to database 
            //after setup build, next we'll need to create appsettings.json w/connectionstrings 
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        
            //We configure famework services to the application below
        public void ConfigureServices(IServiceCollection services)
        {
            //Add MVC to the project
            services.AddMvc();
            //Add EF , to connect to database
            services.AddEntityFramework()
                .AddDbContext<MrFixItContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MrFixItContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //This method below is where we tell ASP.Net what frameworks we want to use in our app
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //app.Use like an HttpModule
            //tell our app to use staticfiles framework
            app.UseStaticFiles();

            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //tell our app to use Identity framework **Need to b b/4 app.UseMvc(), or users won't be able to log in correctly & the app will give you a white screen
            app.UseIdentity();
            //tell the app to use MVC framework
            app.UseMvc(routes =>
            {
                //this is default routing: tells our app to use url: localhost62483/Account/index view/(any parameter will be passed as id and id is optional)
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Index}/{id?}");
            });
            //When app.Run is called in reponse to HTTP request: when there's error, 
            //async tells the compiler that this method can run asynchronously (allows several codes to run (while waiting for the return) at the same time w/o blocking or waiting for other code to complete)
            //await tells the compiler that we'll need to run error.response.writeasync
            //App.Run() is like an Http handler
            //Note** Instead of app.Run(async (error) rewrite by replacing error w/context (conventional)
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Error: You should not see this message. An error has occured.");
            });
        }
    }
}
