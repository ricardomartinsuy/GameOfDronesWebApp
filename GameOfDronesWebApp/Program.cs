using GameOfDronesWebApp.Models;
using GameOfDronesWebApp.Services;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameOfDronesDb")));

builder.Services.AddScoped<GameService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "GameOfDronesFront";

    if (app.Environment.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200"); 
    }
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Game}/{action=Start}/{id?}");

app.Run();
