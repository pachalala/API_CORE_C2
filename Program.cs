using RES_API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SppContext>();

// Add services to the container.

builder.Services.AddControllers();
 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
       builder =>
       {
           builder.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
       });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAnyOrigin");
 

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
 

app.Run();
