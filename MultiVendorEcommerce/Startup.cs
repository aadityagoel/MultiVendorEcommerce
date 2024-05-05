using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories;
using System.Security.Claims;

namespace MultiVendorEcommerce
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Register the configuration
            services.AddSingleton(Configuration);

            services.AddRazorPages();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Schema_Customer";
            })
            .AddCookie("Schema_Admin", options =>
            {
                options.LoginPath = "/admin/login";
                options.LogoutPath = "/admin/login/logout";
                options.AccessDeniedPath = "/admin/login/accessDenied";
            })
            .AddCookie("Schema_Vendor", options =>
            {
                options.LoginPath = "/vendor/login";
                options.LogoutPath = "/vendor/login/logout";
                options.AccessDeniedPath = "/vendor/login/accessDenied";
            })
            .AddCookie("Schema_Customer", options =>
            {
                options.LoginPath = "/customer/login";
                options.LogoutPath = "/customer/login/logout";
                options.AccessDeniedPath = "/customer/login/accessDenied";
            });


            //// Add services to the container.
            services.AddControllersWithViews();


            services.AddControllersWithViews().AddSessionStateTempDataProvider();
            services.AddSession();

            // Retrieve the connection string from the configuration
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // Configure your DbContext with the connection string
            services.AddDbContext<DatabaseContextEntities>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IMembership, MembershipRepository>();
            services.AddScoped<IPackage, PackageRepository>();
            services.AddScoped<IPhoto, PhotoRepository>();
            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<IRole, RoleRepository>();
            services.AddScoped<ISlideShow, SlideShowRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                var principal = new ClaimsPrincipal();

                var result1 = await context.AuthenticateAsync("Schema_Admin");
                if (result1.Principal != null)
                {
                    principal.AddIdentities(result1.Principal.Identities);
                }

                var result2 = await context.AuthenticateAsync("Schema_Vendor");
                if (result2.Principal != null)
                {
                    principal.AddIdentities(result2.Principal.Identities);
                }

                var result3 = await context.AuthenticateAsync("Schema_Customer");
                if (result3.Principal != null)
                {
                    principal.AddIdentities(result3.Principal.Identities);
                }

                context.User = principal;
                await next();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
