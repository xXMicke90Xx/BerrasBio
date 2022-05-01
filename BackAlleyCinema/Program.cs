using BackAlleyCinema.DataBaseAccess;
using BackAlleyCinema.Interfaces;
using BackAlleyCinema.Models;
using BackAlleyCinema.Services;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var cultureSupported = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("sv-SE")
    };

    options.DefaultRequestCulture = new RequestCulture("sv-SE");
    options.SupportedCultures = cultureSupported;
    options.SupportedUICultures = cultureSupported;


});

//använda scoped i ställer?
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<CinemaDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<CinemaDbContext>();
builder.Services.AddScoped<MovieSorter>();
builder.Services.AddScoped<AddObjects>();
builder.Services.AddTransient<Saloon>();




builder.Services.AddRazorPages();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
