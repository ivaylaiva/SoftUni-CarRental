using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services;
using SoftUni_CarRental.Services.Interfaces;

namespace SoftUni_CarRental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<CarRentalDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //    .AddEntityFrameworkStores<CarRentalDbContext>();
            builder.Services.AddIdentity<User, Role>(options =>
            {
                options.Stores.MaxLengthForKeys = 128;
            })
                .AddEntityFrameworkStores<CarRentalDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddRoles<Role>();

            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<ICarCardService, CarCardService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ITestimonialService, TestimonialService>();
            builder.Services.AddScoped<IIdentityUserRoleService, IdentityUserRoleService>();
            builder.Services.AddScoped<IIdentityRolesService, IdentityRolesService>();
            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IRentService, RentService>();

            builder.Services.AddRazorPages();

            builder.Services.AddControllersWithViews();



            var app = builder.Build();



            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
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

            app.MapRazorPages();

            app.Run();
        }
    }
}