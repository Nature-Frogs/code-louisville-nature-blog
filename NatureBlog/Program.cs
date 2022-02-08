using Microsoft.EntityFrameworkCore;
using NatureBlog.DAL;
using NatureBlog.DAL.Models;
using NatureBlog.Services;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var cxString = configuration.GetConnectionString("SQLConnectionString");
if (string.IsNullOrWhiteSpace(cxString))
{
    cxString = Environment.GetEnvironmentVariable("SQLConnectionString");
}


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogDatabaseContext>(options => options.UseSqlServer(cxString));
builder.Services.AddScoped<IBlogPostService, BlogPostService>();

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
