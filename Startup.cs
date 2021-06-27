using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Planifiqator.Data;
using Planifiqator.Data.Entities;
using Planifiqator.Data.Repositories;
using Planifiqator.Services;

namespace Planifiqator
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddDbContext<DatabaseContext>();
            services.AddTransient<DatabaseSeeder>();
            services.AddScoped<IAppRepository, AppRepository>();
            services.AddScoped<IUtilizatorRepository, UtilizatorRepository>();
            services.AddScoped<IUtilizatorService, UtilizatorService>();
            services.AddScoped<IPlanificariVacanteRepository, PlanificariVacanteRepository>();
            services.AddScoped<IPlanificariVacanteService, PlanificariVacanteService>();
            services.AddScoped<IDestinatiiRepository, DestinatiiRepository>();
            services.AddScoped<IDestinatiiService, DestinatiiService>();
            services.AddScoped<INotiteRepository, NotiteRepository>();
            services.AddScoped<INotiteService, NotiteService>();
            services.AddScoped<IUtilizatorRecompensatRepository, UtilizatorRecompensatRepository>();
            services.AddScoped<IUtilizatorRecompensatService, UtilizatorRecompensatService>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(config =>
            {
                config.MapRazorPages();
                config.MapControllerRoute("Default",
                    "/{controller}/{action}/{id?}",
                   new { controller = "App", action = "Login" });
            });
        }
    }
}
