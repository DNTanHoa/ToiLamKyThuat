using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToiLamKyThuat.Data.Models;
using ToiLamKyThuat.Data.Respositories;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using GleamTech.AspNet.Core;
using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using AspNetCore.SEOHelper;
using ToiLamKyThuat.Data.Helpers;

namespace ToiLamKyThuat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddControllers(options => options.EnableEndpointRouting = false)
                    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddDbContext<ToiLamKyThuatContext>();
            services.AddTransient<IPostRespository, PostRespository>();
            services.AddTransient<IUserRespository, UserRespository>();
            services.AddTransient<IMasterDataRespository, MasterDataRespository>();
            services.AddGleamTech();
            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
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
            app.UseHttpsRedirection();

            app.UseXMLSitemap(env.ContentRootPath + AppGlobal.SitemapFTP);

            app.UseGleamTech();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "PostDetail",
                    pattern: "{MetaTitle}-{Id}.html",
                    defaults: new { controller = "Home", action = "Detail" });

                endpoints.MapControllerRoute(
                    name: "IndexByMasterData",
                    pattern: "{MetaTitle}",
                    defaults: new { controller = "Home", action = "IndexByMasterData" });

                endpoints.MapControllerRoute(
                    name: "About",
                    pattern: "about.html",
                    defaults: new { controller = "Home", action = "About" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
