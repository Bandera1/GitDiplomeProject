using DiplomeProject.DB;
using DiplomeProject.DB.IdentityModels;
using DiplomeProject.DB.Models;
using DiplomeProject.Repositories.Implementations;
using DiplomeProject.Repositories.Interfaces;
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

        builder.Services.AddTransient<IRepository<Product>, ProductRepository>();

        builder.Services.AddIdentity<DbUser, IdentityRole>(options =>
        {
            options.Stores.MaxLengthForKeys = 256;
            options.Password.RequiredLength = 6;
        })
               .AddEntityFrameworkStores<EFDbContext>()
               .AddDefaultTokenProviders();


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();        
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseDeveloperExceptionPage();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });

        app.MapFallbackToFile("index.html"); ;

        app.Run();
    }
}