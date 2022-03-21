using BusinessLayer.Manager;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ShopCheckWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Settings>(new Settings { ConnectionString = @"Data Source=DESKTOP-JUEFI31;Initial Catalog=ShopCheck;Integrated Security=True" });
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<CustomerManager>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ProductManager>();
            services.AddSingleton<IInstallmentRepository, InstallmentRepository>();
            services.AddSingleton<InstallmentManager>();
            services.AddSingleton<ISalesRepository, SalesRepository>();
            services.AddSingleton<SalesManager>();
            services.AddControllersWithViews();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Customer}/{action=Index}/{id?}");
            });
        }
    }
}
