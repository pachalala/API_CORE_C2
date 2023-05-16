using RES_API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestContext>();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
 

app.Run();
