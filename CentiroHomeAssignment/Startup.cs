using CentiroHomeAssignment.Controllers;
using CentiroHomeAssignment.DataReader;
using CentiroHomeAssignment.HostedServices;
using CentiroHomeAssignment.Repositories;
using CentiroHomeAssignment.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CentiroHomeAssignment
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
            services.AddDbContext<CentiroHomeAssignmentContext>(opt =>
                opt.UseInMemoryDatabase(databaseName: "CentiroHomeAssignment"));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddSingleton<Settings>();
            services.AddScoped<IFileReader, CSVFileReader>();

            services.AddScoped<OrdersService>();    
            services.AddScoped<OrderDTOFromFileToDB>();

            services.AddHostedService<OrdersFileWatcherHostedService>();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}