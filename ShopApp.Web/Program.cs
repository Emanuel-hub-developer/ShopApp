
using ShopApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopApp.DAL.Interfaces;
using ShopApp.DAL.Daos;
using Microsoft.AspNetCore.Builder;
namespace ShopApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            // Add services to the container.

            builder.Services.AddDbContext<DAL.Context.ShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDb")));
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDaoCategory,DaoCategory>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

    }
}
