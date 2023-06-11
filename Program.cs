using DiplomeProject.DB;
using DiplomeProject.DB.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Add services to the container.
        builder.Services.AddDbContext<EFDbContext>(options =>
                     options.UseSqlServer(connectionString));

        builder.Services.AddIdentity<DbUser, IdentityRole>(options =>
        {
            options.Stores.MaxLengthForKeys = 256;
            options.Password.RequiredLength = 6;
        })
               .AddEntityFrameworkStores<EFDbContext>()
               .AddDefaultTokenProviders();

        builder.Services.AddAuthentication();
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html"); ;

        app.Run();
    }
}