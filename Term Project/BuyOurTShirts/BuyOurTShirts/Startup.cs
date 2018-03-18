using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BOTSwebsite.Models;
using BOTSwebsite.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BuyOurTShirts
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
            services.AddDbContext<BotsDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BotsContext")));
            services.AddMvc();
            services.AddTransient<IBlogRepository, BlogRepo>();
            services.AddTransient<ICommentRepository, CommentRepo>();
            services.AddTransient<IMediaRepository, MediaRepo>();
            services.AddTransient<IShowRepository, ShowRepo>();
            services.AddTransient<IVenueRepository, VenueRepo>();



            services.AddIdentity<Account, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<BotsDbContext>()
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
    }
}
