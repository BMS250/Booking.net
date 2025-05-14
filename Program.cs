using Microsoft.EntityFrameworkCore;
using Booking.Data;
using Microsoft.AspNetCore.Identity;
using Booking.Repositories;
using Booking.Services;

namespace Booking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<IEventService, EventService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();

            // Configure Identity
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            // Fix: Use builder.Configuration instead of undefined 'config'
            builder.Services.AddAuthentication()
               .AddGoogle(options =>
               {
                   IConfigurationSection googleAuthNSection =
                   builder.Configuration.GetSection("Authentication:Google");
                   options.ClientId = googleAuthNSection["ClientId"];
                   options.ClientSecret = googleAuthNSection["ClientSecret"];

                   // Ensure the following NuGet package is installed in your project:
                   // Microsoft.AspNetCore.Authentication.Google
               });
               //.AddFacebook(options =>
               //{
               //    IConfigurationSection FBAuthNSection =
               //    builder.Configuration.GetSection("Authentication:FB");
               //    options.ClientId = FBAuthNSection["ClientId"];
               //    options.ClientSecret = FBAuthNSection["ClientSecret"];
               //})
               //.AddMicrosoftAccount(microsoftOptions =>
               //{
               //    microsoftOptions.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"];
               //    microsoftOptions.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"];
               //});


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
            app.MapRazorPages();
            app.MapDefaultControllerRoute();
            app.MapControllerRoute(
                name: "default",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
