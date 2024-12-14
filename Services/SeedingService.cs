using Humanizer.Localisation;
using ProjetoSistema.Data;
using ProjetoSistema.Models;
using System.Security.Cryptography;

namespace ProjetoSistema.Services
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
                return; // Db já foi semeado.
            }

            Moto m1 = new Moto(1, "Yamaha", "Fz125", "SEX-69B6", "PRETA", 200, 2024);
            Moto m2 = new Moto(2, "Honda", "CB300R", "XYZ-12A3", "VERMELHA", 300, 2023);
            Moto m3 = new Moto(3, "Suzuki", "GSX-R750", "ABC-34C5", "AZUL", 750, 2022);
            Moto m4 = new Moto(4, "Kawasaki", "Ninja ZX-6R", "JKL-56D7", "VERDE", 636, 2021);
            Moto m5 = new Moto(5, "BMW", "S1000RR", "QWE-78E9", "BRANCA", 1000, 2025);
            Moto m6 = new Moto(6, "Ducati", "Panigale V4", "RTY-90F1", "VERMELHA", 1103, 2023);
            Moto m7 = new Moto(7, "Yamaha", "MT-07", "UOP-11G2", "CINZA", 689, 2024);
            Moto m8 = new Moto(8, "Triumph", "Speed Triple 1200 RS", "VBN-22H3", "PRETA", 1160, 2023);
            Moto m9 = new Moto(9, "Harley-Davidson", "Sportster S", "MNB-33I4", "PRETA", 1252, 2022);
            Moto m10 = new Moto(10, "KTM", "Duke 790", "ZXC-44J5", "LARANJA", 799, 2024);

            await _context.Motos.AddRangeAsync(
                m1, m2, m3, m4, m5, m6, m7, m8, m9, m10
            );

            await _context.SaveChangesAsync();

        }
    }
}
    
    
