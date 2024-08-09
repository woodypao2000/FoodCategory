using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC8.Data;

namespace MVC8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); //�Ыؤ@�� WebApplication ����

            // Add services to the container.
            builder.Services.AddControllersWithViews();//�NView �[�J�ܮe��
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();//�Ы� app = �Q��builder.Build �t�m

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) //�p�G���b�}�o���Ҥ�
            {
                app.UseExceptionHandler("/Home/Error");//�������`�B�z
 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //HSTS (HTTP Strict Transport Security) �O�@�غ����w�������A�Ω󨾤���H�����C
                app.UseHsts();
            }
            app.UseHttpsRedirection();  //Https
            app.UseStaticFiles();       //�R�A���
            app.UseRouting();           //��������
            app.UseAuthorization();     //���v
            app.MapControllerRoute(     //Controller ����
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();                  //�Ұ�
        }
    }
}