using Microsoft.EntityFrameworkCore;
using NatureBlog.DAL;
using NatureBlog.DAL.Models;
using NatureBlog.Services;
using NatureBlog.Web;
using System.Security.Claims;

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

builder.Services.AddAuthentication(AppConstants.COOKIE_AUTH_SCHEME_NAME)
    .AddCookie(AppConstants.COOKIE_AUTH_SCHEME_NAME, options =>
    {
        options.Cookie.Name = AppConstants.COOKIE_AUTH_SCHEME_NAME;
        options.LoginPath = "/account";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AppConstants.BLOG_ENTRY_POLICY_NAME, policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
