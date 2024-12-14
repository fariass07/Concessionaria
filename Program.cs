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
            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<MotoService, MotoService>(); // Register MotoService
            builder.Services.AddScoped<MotoContext, MotoContext>();

            var connectionString = builder.Configuration.GetConnectionString("MotoContext"); // Use correct key
            builder.Services.AddDbContext<MotoContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                // Criamos um escopo de execução nos serviços, usamos o GetRequiredService para selecionar o serviço a ser executado e selecionamos o método Seed
                app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
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