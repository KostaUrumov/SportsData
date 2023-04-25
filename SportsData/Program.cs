using Microsoft.EntityFrameworkCore;
using SportsData.Data;
using SportsData.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SportsDataDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnect")));
builder.Services.AddScoped<CoachService>();
builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<StadiumService>();


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
