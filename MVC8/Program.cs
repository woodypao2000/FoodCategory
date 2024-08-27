using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC8.DataAccess.Data;
using MVC8.DataAccess.Repository;
using MVC8.DataAccess.Repository.IRepository;

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
            builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();//�ޥα��f�P��{
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
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
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();                  //�Ұ�
        }
    }
}