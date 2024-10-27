using GameOfDronesWebApp.Models;
using GameOfDronesWebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameOfDronesDb")));

builder.Services.AddScoped<GameService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()   
                   .AllowAnyMethod()   
                   .AllowAnyHeader();  
        });
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers(); 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Game}/{action=Start}/{id?}");

app.Run();

