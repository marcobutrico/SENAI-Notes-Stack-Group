using OrganizedNotesAPI.Models;

namespace OrganizedNotesAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> GetByEmailAsync(string email);
        Task AddAsync(Usuario usuario);
    }
}
