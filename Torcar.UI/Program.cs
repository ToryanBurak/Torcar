using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Torcar.REPOSITORY;
using Torcar.SERVICE.Mapping;
using Torcar.UI.Modules;

namespace Torcar.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddAutoMapper(typeof(MapProfile));
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<AppDbContext>(x=> {
                x.UseMySQL(builder.Configuration.GetConnectionString("MySqlCon"));
            });
            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.Cookie.Name = "LoginUserId";
                    x.ExpireTimeSpan=TimeSpan.FromDays(7);
                    x.LoginPath = "/Identity/Login";
                    x.LogoutPath = "/Identity/Logout";
                    x.AccessDeniedPath = "/Home/AccessDenied";
                    
                });
            builder.Host.UseServiceProviderFactory
            (new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceUnitModule()));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}