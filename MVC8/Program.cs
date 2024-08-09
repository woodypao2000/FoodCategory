using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC8.Data;

namespace MVC8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); //創建一個 WebApplication 物件

            // Add services to the container.
            builder.Services.AddControllersWithViews();//將View 加入至容器
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();//創建 app = 利用builder.Build 配置

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) //如果不在開發環境中
            {
                app.UseExceptionHandler("/Home/Error");//全局異常處理
 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //HSTS (HTTP Strict Transport Security) 是一種網絡安全策略，用於防止中間人攻擊。
                app.UseHsts();
            }
            app.UseHttpsRedirection();  //Https
            app.UseStaticFiles();       //靜態文件
            app.UseRouting();           //中介路由
            app.UseAuthorization();     //授權
            app.MapControllerRoute(     //Controller 路由
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();                  //啟動
        }
    }
}