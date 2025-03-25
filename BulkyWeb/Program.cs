using BulkyWeb.Application.CustomLib;
using BulkyWeb.Application.CustomLib.Interfaces;
using BulkyWeb.Application.NotificationServices;
using BulkyWeb.Application.NotificationServices.Interfaces;
using BulkyWeb.Application.Services;
using BulkyWeb.Infrastructure.Data;
using BulkyWeb.Services.Serilog;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Identity/SignIn";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    option.AccessDeniedPath = "/NotFound/Index";
});
builder.Services.AddAuthorization(options =>
{
    //foreach (var eachItem in authorizeList)
    //{
    //    options.AddPolicy(each, policy => policy.RequireClaim("Authorize", eachItem));
    //}
    options.AddPolicy("Admin", policy => policy.RequireClaim("Department", "IT"));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextAccessor>();

//Register services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<_ISerilog, _Serilog>();
builder.Services.AddScoped<ICustomLib, CustomLib>();
builder.Services.AddScoped<INotification, EmailNotification>(); //auto instant 
builder.Services.AddScoped<INotification>(em => new EmailNotification("input ip mail")); // when using a INotication => Inotication notification = new EmailNotification("input ip mail")
builder.Services.AddScoped<INotificationService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add loging 
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateLogger();

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Bulky API",
        Description = "A Swagger Web Service for Testing API Endpoints in .NET 7",
    });

    // Additional Swagger configurations can go here
    // For example, adding XML comments, security definitions, etc.
});

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    dbContext.Database.Migrate(); // Auto-migrate at runtime
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
}
else
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    // Enable middleware to serve Swagger UI, specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bulky API");
        c.RoutePrefix = "swagger";
        //c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root (http://localhost:<port>/)
    });
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
