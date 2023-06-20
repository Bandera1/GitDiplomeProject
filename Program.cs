using DiplomeProject.DB;
using DiplomeProject.DB.IdentityModels;
using DiplomeProject.DB.Models;
using DiplomeProject.Repositories.Implementations;
using DiplomeProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using StudentAccountingProject.Helpers;
using StudentAccountingProject.Services;

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
        builder.Services.AddTransient<IRepository<Producer>, ProducerRepository>();
        builder.Services.AddTransient<IRepository<Category>, ÑategoryRepository>();

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

        builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
        {
            builder.WithOrigins("https://localhost:44430").
            SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
        }));

        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();        
        }

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors("corsapp");
        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseDeveloperExceptionPage();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");


        #region InitStaticFiles ProductImages
        string pathUsers = InitStaticFiles
           .CreateFolderServer(app.Environment, app.Configuration,
               new string[] { "ImagesPath", "ImagesPathProducts" });
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(pathUsers),
            RequestPath = new PathString('/' + app.Configuration.GetValue<string>("ProductssUrlImages"))
        });
        #endregion

        #region InitStaticFiles Images
        string pathRoot = InitStaticFiles
            .CreateFolderServer(app.Environment, app.Configuration,
                new string[] { "ImagesPath" });

        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(pathRoot),
            RequestPath = new PathString("/" + app.Configuration.GetValue<string>("UrlImages"))
        });
        #endregion;

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });

        app.MapFallbackToFile("index.html"); ;

        app.Run();
    }
}