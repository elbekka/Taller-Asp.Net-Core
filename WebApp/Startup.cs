using DAL;
using Infrastructure;
using Infrastructure.Programmers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddRepository();

            /*
             AddMvc(setup =>
                    {
                        setup.EnableEndpointRouting = false;
                        setup.Filters.Add<HttpActionFilter>();
                    })
             */
            //services.AddMvc(setup =>
            //{
            //    setup.EnableEndpointRouting = false;
            //});
            services.AddControllersWithViews();
            services.AddLogging();
            if (Configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<GestorContext>(options =>
                    options.UseInMemoryDatabase("Gestor"));
            }
            else
            {
                services.AddDbContext<GestorContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(GestorContext).Assembly.FullName)));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            //app.UseRouting().UseMvc(
            //    endpoint =>
            //    {
            //        endpoint.MapRoute(
            //            name: "default",
            //            template: "{controller=Home}/{action=Index}"
            //            );
            //    }
            //    );


            // app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
