using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo.Repositories;
using CrossOutCommunity.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CrossOutCommunity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CrossOutCommunity
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
            services.AddDbContext<CCDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CCDbContext")));
            services.AddMvc();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();


            services.AddIdentity<Account, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<CCDbContext>()
                          .AddDefaultTokenProviders();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();   // Must precede app.UseMvc!!!
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }


        //    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseBrowserLink();
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //    }

        //    app.UseStaticFiles();

        //    app.UseMvc(routes =>
        //    {
        //        routes.MapRoute(
        //            name: "default",
        //            template: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}
    }
}
