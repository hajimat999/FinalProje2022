using FinallyFinalProject.DAL;
using FinallyFinalProject.Models;
using FinallyFinalProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FinallyFinalProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer("Server=DESKTOP-8VHJ67S\\SQLEXPRESS01;Database=999Database;Integrated Security=true;Trusted_Connection=true");

            });
            services.AddIdentity<AppUser,IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.AllowedForNewUsers = true;
                opt.User.RequireUniqueEmail = false;
                opt.Password.RequiredUniqueChars = 3;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = true;  
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
                opt.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<LayoutService>();
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
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
                    );


                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=home}/{action=index}/{id?}"
                    );
            });
        }
    }
}
