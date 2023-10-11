using Microsoft.EntityFrameworkCore;
using RevolutionFactory.Data;
using RevolutionFactory.Data.Interfaces;
using RevolutionFactory.Data.Interfaces.Repositories;
using RevolutionFactory.Data.Repositories;
using RevolutionFactory.Domain.Interfaces;
using RevolutionFactory.Domain.Services;
using Tweetinvi.Models;

var builder = WebApplication.CreateBuilder(args);

// DB Context
builder.Services.AddDbContext<RevolutionFactoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RevolutionFactoryDbConnectionString")));

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ITweetRepository, TweetRepository>();

builder.Services.AddTransient<ITweetService, TweetService>();

builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
