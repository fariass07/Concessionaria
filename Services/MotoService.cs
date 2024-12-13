using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using ProjetoSistema.Data;
using ProjetoSistema.Models;
using ProjetoSistema.Services.Exceptions;
using System.Data;

namespace ProjetoSistema.Services
{
    public class MotoService
    {
        private readonly MotoContext _context;

        public MotoService(MotoContext context)
        {
            _context = context;
        }

        public async Task<List<Moto>?> FindAllAsync()
        {
            return await _context.Motos.ToListAsync();
        }

        public async Task InsertAsync(Moto moto)
        {
            _context.Add(moto);
            await _context.SaveChangesAsync();
        }

        public async Task<Moto?> FindByIdAsync(int id)
        {
            return await _context.Motos.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Motos.FindAsync(id);
                _context.Motos.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }

        public async Task UpdateAsync(Moto moto)
        {
            bool hasAny = await _context.Motos.AnyAsync(x => x.Id == moto.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }

            try
            {
                {
                    _context.Update(moto);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcorrencyException(ex.Message);
            }
        }
    }
}
