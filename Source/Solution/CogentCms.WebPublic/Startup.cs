using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CogentCms.Core.Auth;
using CogentCms.Core.Blogs;
using CogentCms.Core.Sql;
using CogentCms.Web.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CogentCms.WebPublic
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews()
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Add("/{0}.cshtml");
                });

            services.AddHttpContextAccessor();

            services.AddScoped(provider => new SqlConnectionFactory(Environment.GetEnvironmentVariable("Cogent_ConnectionString")));
            services.AddScoped<ICogentUser, WebCogentUser>();
            services.AddScoped<IBlogService, BlogService>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
