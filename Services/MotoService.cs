using ProjetoSistema.Data;
using ProjetoSistema.Models;

namespace ProjetoSistema.Services
{
    public class MotoService
    {
        private readonly MotoContext _context;

        public MotoService(MotoContext context)
        {
            _context = context;
        }

        internal async Task<List<Moto>?> FindAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
