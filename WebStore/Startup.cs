ï»¿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Services;

namespace WebStore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEmloyeesData, InMemoryEmployeesData>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

#if DEBUG
            // ÐÐ°Ð³ÑÑÐ·ÐºÐ° ÑÐµÑÑÐ¾Ð²ÑÑ Ð´Ð°Ð½Ð½ÑÑ Ð² Ð¿Ð°Ð¼ÑÑÑ.
            Data.TestData.Load();
#endif

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            // ÐÐºÐ»ÑÑÐµÐ½Ð¸Ðµ Ð¾Ð±ÑÐ»ÑÐ¶Ð¸Ð²Ð°Ð½Ð¸Ñ ÑÑÐ°ÑÐ¸ÑÐµÑÐºÐ¸Ñ ÑÐ°Ð¹Ð»Ð¾Ð².
            app.UseStaticFiles();

            app.UseRouting();

            app.UseStaticFiles();   // äîáàâëÿåì ïîääåðæêó ñòàòè÷åñêèõ ôàéëîâ

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                // Ð¡ÑÐ°Ð½Ð´Ð°ÑÑÐ½Ð°Ñ Ð¼Ð°ÑÑÑÑÑÐ¸Ð·Ð°ÑÐ¸Ñ Ð¸ÑÐ¿Ð¾Ð»ÑÐ·ÑÐµÑÑÑ Ñ ÐºÐ¾Ð½ÑÑÐ¾Ð»Ð»ÐµÑÐ°Ð¼Ð¸ Ð¸ Ð¿ÑÐµÐ´ÑÑÐ°Ð²Ð»ÐµÐ½Ð¸ÑÐ¼Ð¸.
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
