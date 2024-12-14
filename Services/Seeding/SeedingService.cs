using ProjetoSistema.Data;
using ProjetoSistema.Models;
using Humanizer.Localisation;
using NuGet.Protocol.Plugins;

namespace Bookstore.Services.Seeding
{
    public class SeedingService
    {
        private readonly MotoContext _context;
        public SeedingService(MotoContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (_context.Motos.Any()
               )
            {
                return;
            }

            // (string modelo, int id, string placa, string marca, string cor, int cilindrada, int ano) //
            Moto b1 = new Moto("Yamaha", "Fz125", 1, "QIZ 9251", "Preta", 200, 2024);
            Moto m1 = new Moto("Yamaha", "Fz125", 1, "QIZ 9251", "Preta", 200, 2024);
            Moto m2 = new Moto("Honda", "CB 500F", 2, "ABC 1234", "Vermelha", 500, 2023);
            Moto m3 = new Moto("Kawasaki", "Ninja 300", 3, "XYZ 5678", "Verde", 300, 2022);
            Moto m4 = new Moto("Suzuki", "Hayabusa", 4, "JKL 8765", "Azul", 1300, 2024);
            Moto m5 = new Moto("Ducati", "Monster 797", 5, "MNO 5432", "Branca", 803, 2023);
            Moto m6 = new Moto("BMW", "G 310 R", 6, "PQR 6543", "Prata", 313, 2021);
            Moto m7 = new Moto("Harley-Davidson", "Iron 883", 7, "STU 9876", "Preta", 883, 2022);
            Moto m8 = new Moto("Triumph", "Bonneville T120", 8, "VWX 1357", "Cinza", 1200, 2023);
            Moto m9 = new Moto("KTM", "Duke 390", 9, "YZA 2468", "Laranja", 390, 2024);
            Moto m10 = new Moto("Royal Enfield", "Himalayan", 10, "BCD 1122", "Verde Militar", 411, 2022);

            // Adicionando Motos
            await _context.Motos.AddRangeAsync(
                m1, m2, m3, m4, m5, m6, m7, m8, m9, m10
            );

            // Salvando alterações no banco
            await _context.SaveChangesAsync();
        }
    }
}