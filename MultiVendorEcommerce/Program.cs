using Microsoft.EntityFrameworkCore;
using MultiVendorEcommerce.Models;

var builder = WebApplication.CreateBuilder(args);

// Set up configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true)
    .Build();

// Register the configuration
builder.Services.AddSingleton(configuration);

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
