using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Kahla.Server.Data;
using Kahla.Server.Models;
using Kahla.Server.Services;
using Aiursoft.Pylon;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpOverrides;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Aiursoft.Pylon.Services.ToStargateServer;
using Aiursoft.Pylon.Services;

namespace Kahla.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<KahlaDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));

            services.AddIdentity<KahlaUser, IdentityRole>()
                .AddEntityFrameworkStores<KahlaDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddTransient<AuthService<KahlaUser>>();
            services.AddTransient<HTTPService>();
            services.AddTransient<PushMessageService>();
            services.AddTransient<PushKahlaMessageService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, KahlaDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseEnforceHttps();
            }
            app.UseAiursoftAuthenticationFromConfiguration(Configuration, "Kahla");
            app.UseHandleKahlaOptions();
            app.UseAuthentication();
            app.UseLanguageSwitcher();
            app.UseMvcWithDefaultRoute();
        }
    }
}
