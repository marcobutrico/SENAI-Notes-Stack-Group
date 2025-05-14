using OrganizedNotesAPI.Models;
using OrganizedNotesAPI.Interfaces;

namespace OrganizedNotesAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContext _context;
        public UsuarioRepository(DbContext context) => _context = context;

        public async Task<Usuario> GetByIdAsync(int id) => await _context.Set<Usuario>().FindAsync(id);
        public async Task<Usuario> GetByEmailAsync(string email) =>
            await _context.Set<Usuario>().FirstOrDefaultAsync(u => u.Email == email);
        public async Task AddAsync(Usuario usuario)
        {
            await _context.Set<Usuario>().AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
