using Microsoft.EntityFrameworkCore;
using ProjetoSistema.Models;

namespace ProjetoSistema.Data
{
    public class MotoContext : DbContext  
    {
        public MotoContext(DbContextOptions<MotoContext> options) : base(options) 
        { 

        }

        public DbSet<Moto> Motos { get; set; }
    }
}
