﻿using GameOfDronesWebApp.Models;
using GameOfDronesWebApp.Services;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;

namespace GameOfDronesWebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<GameDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("GameOfDronesDb")));

        builder.Services.AddScoped<GameService>();

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

        app.UseAuthorization();

        app.MapControllers(); 

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";

            spa.UseAngularCliServer(npmScript: "start");
        });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Game}/{action=Start}/{id?}");

        app.Run();
    }
}

