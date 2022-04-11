using ECommerce.Business.Abstract;
using ECommerce.Business.Caching;
using ECommerce.Business.Concrete;
using ECommerce.Business.Helpers;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Concrete;
using ECommerce.Web.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web
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
            //dependency Injection 
            services.AddMemoryCache();
            #region Old
            services.AddScoped<ISettingService, SettingManager>();
            services.AddScoped<ISettingDal, EfSettingDal>();

            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderDal, EfSliderDal>();

            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IBrandDal, EfBrandDal>();

            services.AddScoped<IUserService, UserManager>();//----
            services.AddTransient<IUserDal, EfUserDal>();//----

            services.AddScoped<IUserTokenService, UserTokenManager>();//----
            services.AddTransient<IUserTokenDal, EfUserTokenDal>();//---- 
            #endregion

            services.AddScoped<ICategoryService, CategoryManager>();//----
            services.AddTransient<ICategoryDal, EfCategoryDal>();//----

            services.AddScoped<ICategoryProductService, CategoryProductManager>();//----
            services.AddTransient<ICategoryProductDal, EfCategoryProductDal>();//----

            services.AddScoped<IProductImageService, ProductImageManager>();//----
            services.AddTransient<IProductImageDal, EfProductImageDal>();//----

            services.AddScoped<IProductService, ProductManager>();//----
            services.AddTransient<IProductDal, EfProductDal>();//----


            services.AddScoped<IOrderService, OrderManager>();//----
            services.AddTransient<IOrderDal, EfOrderDal>();//----



            services.AddScoped<IProductDetailService, ProductDetailManager>();//----
            services.AddTransient<IProductDetailDal, EfProductDetailDal>();//----

            services.AddSingleton<IMemoryCacheService, MemoryCacheManager>();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<IStringHelpers, StringHelpers>();//----
            services.AddSingleton<ICookieHelper, CookieHelper>();//----


            services.AddScoped<IViewRenderService, ViewRenderService>();//----

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
                name: "kategory",
                pattern: "/kategori/{name}",
                defaults: new { controller = "Category", action = "Index" });

                endpoints.MapControllerRoute(
               name: "productdetail",
               pattern: "/urun/{name}",
               defaults: new { controller = "Product", action = "Index" });

                endpoints.MapControllerRoute(
                name: "producthtml",
                pattern: "/producthtml/{name?}/{page?}",
                defaults: new { controller = "Category", action = "ProductPost" });



                endpoints.MapControllerRoute(
                name: "baskethtml",
                pattern: "/baskethtml",
                defaults: new { controller = "Product", action = "AddBasket" });

                endpoints.MapControllerRoute(
                name: "getbasket",
                pattern: "/getbasket",
                defaults: new { controller = "Product", action = "GetBasket" });

                endpoints.MapControllerRoute(
             name: "plusproduct",
             pattern: "/plusproduct",
             defaults: new { controller = "Product", action = "PlusMinusBAsketProduct" });


                endpoints.MapControllerRoute(
        name: "calculatebasket",
        pattern: "/calculatebasket",
        defaults: new { controller = "Product", action = "CalculateBasket" });


                endpoints.MapControllerRoute(
        name: "basket",
        pattern: "/basket",
        defaults: new { controller = "Product", action = "CalculateBasket" });

                endpoints.MapControllerRoute(
        name: "chechkout",
        pattern: "/checkout",
        defaults: new { controller = "CheckOut", action = "Index" });

                endpoints.MapControllerRoute(
        name: "chechkoutok",
        pattern: "/checkoutok",
        defaults: new { controller = "CheckOut", action = "CheckOut" });

                endpoints.MapControllerRoute(name: "AdminArea", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
