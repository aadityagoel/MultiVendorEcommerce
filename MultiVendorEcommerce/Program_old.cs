using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MultiVendorEcommerce.Models;

var builder = WebApplication.CreateBuilder(args);

// Set up configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true)
    .Build();

// Register the configuration
builder.Services.AddSingleton(configuration);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Schema_Customer";
})
.AddCookie("Schema_Admin", options =>
 {
     options.LoginPath = "/admin/login";
     options.LogoutPath = "/admin/login/logout";
     options.AccessDeniedPath = "/admin/login/accessDenied";
     // })
     //.AddCookie("Schema_Vendor", options =>
     // {
     //     options.LoginPath = "/vendor/account";
     //     options.LogoutPath = "/vendor/account/logout";
     //     options.AccessDeniedPath = "/vendor/account/accessDenied";
     // })
     //.AddCookie("Schema_Customer", options =>
     // {
     //     options.LoginPath = "/customer/account";
     //     options.LogoutPath = "/customer/account/logout";
     //     options.AccessDeniedPath = "/customer/account/accessDenied";
 });

// Add services to the container.
builder.Services.AddControllersWithViews();

// Retrieve the connection string from the configuration
string connectionString = configuration.GetConnectionString("DefaultConnection");

// Configure your DbContext with the connection string
builder.Services.AddDbContext<DatabaseContextEntities>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

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
