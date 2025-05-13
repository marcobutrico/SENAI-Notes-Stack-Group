using OrganizedNotesAPI.Models;
using OrganizedNotesAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OrganizedNotesAPI.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly DbContext _context;
        public NotaRepository(DbContext context) => _context = context;

        public async Task<List<Nota>> GetAllAsync(int usuarioId) =>
            await _context.Set<Nota>().Where(n => n.UsuarioId == usuarioId).ToListAsync();

        public async Task<Nota> GetByIdAsync(int id) => await _context.Set<Nota>().FindAsync(id);
        public async Task AddAsync(Nota nota)
        {
            await _context.Set<Nota>().AddAsync(nota);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Nota nota)
        {
            _context.Set<Nota>().Update(nota);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var nota = await GetByIdAsync(id);
            if (nota != null)
            {
                _context.Set<Nota>().Remove(nota);
                await _context.SaveChangesAsync();
            }
        }
    }
}
