using App.ExtendMethods;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP.NETMVC.Models;

namespace ASP.NETMVC
{
    public class Startup
    {
        public static string ContentRootPath { get; set; } 
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            ContentRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => {
                string conectionString = Configuration.GetConnectionString("AppMVCConectionString");
                options.UseSqlServer(conectionString);
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
            services.Configure<RazorViewEngineOptions>(options => {
                // tim nhung file trong  View/Controller/Action.cshtml
                //Tim trong MyView/Controller/Action.cshtml
                // {0} TEn Action
                //{1} Ten Controller  {2} ten Area
                
                options.ViewLocationFormats.Add("/MyView/{1}/{0}.cshtml" + RazorViewEngine.ViewExtension);
            });
            //services.AddSingleton<ProductService>();
            services.AddSingleton(typeof( ProductService));
            services.AddSingleton<PanetService>();
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
            app.AddStatusCodePage(); // Code 400-599
            app.UseRouting();

            app.UseAuthorization(); // Xác định danh tính
            app.UseAuthorization(); // Xác thực quyền truy cập

            app.UseEndpoints(endpoints =>
            {
                //URL;/{controler}/{action}/{id?}
                //Abc/XYZ Controller=Abc, goi method XYZ
                //Home/Index
                //endpoints.MapControllers;
                //endpoints.MapControllersRoute;
                //endpoints.MapDefaultControllerRoute;
                //endpoints.MapAreaControllerRoute

                //URL = start-here/TenController/Action/id
                endpoints.MapGet("/sayhi", async (context) =>
                {
                    await context.Response.WriteAsync($"Hello ASP.NET MVC{DateTime.Now}");
                });




                //[AcceptVerbs]



                //[Route]
                endpoints.MapControllerRoute(
                    name: "First",
                    pattern: "{url}/{id?}",
                    defaults: new
                    {
                        controller = "First",
                        action = "ViewProduct"
                    },
                    constraints: new
                    {
                        url = new StringRouteConstraint("xemsanpham"),
                        id = new RangeRouteConstraint(2, 4)
                    }
                    );
                //StringRouteConstraint
                //RegexRouteConstraint

                endpoints.MapAreaControllerRoute(
                    name: "product",
                    pattern: "/{controller}/{action=index}/{id?}",
                    areaName: "ProductManage"
                    );


                //Controller khong co Area
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "/{controller=Home}/{action=index}/{id?}" //Start-HelperResult, Startup-hear/1
                  );
                endpoints.MapRazorPages();
            });
        }
    }
}
