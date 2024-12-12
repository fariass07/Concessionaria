using Microsoft.EntityFrameworkCore;
using ProjetoSistema.Data;
using ProjetoSistema.Services;

namespace ProjetoSistema
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<MotoService>();


            builder.Services.AddDbContext<MotoContext>(options =>
            {
                options.UseMySql(
                    builder
                        .Configuration
                        .GetConnectionString("MotoContext"),
                    ServerVersion
                        .AutoDetect(
                            builder
                                .Configuration
                                .GetConnectionString("MotoContext")
                        )
                );
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
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
