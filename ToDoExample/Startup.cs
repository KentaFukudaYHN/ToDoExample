using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ToDoExample.Data;
using ToDoExample.Interfaces;
using ToDoExample.Services;

namespace ToDoExample
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
            //デバックの実行をし直さなくても、リアルタイムにcshtmlが反映される様に設定
            services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            //DIコンテナにDbContext登録
            services.AddDbContext<ToDoContext>(o =>
            {
                o.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            });

            //DIコンテナにrepository登録
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            //DIコンテナにService登録
            services.AddScoped<IToDoService, ToDoService>();
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
                //app.UseExceptionHandler("/Home/Error");
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
