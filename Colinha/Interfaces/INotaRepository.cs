using OrganizedNotesAPI.Models;

namespace OrganizedNotesAPI.Interfaces
{
    public interface INotaRepository
    {
        Task<List<Nota>> GetAllAsync(int usuarioId);
        Task<Nota> GetByIdAsync(int id);
        Task AddAsync(Nota nota);
        Task UpdateAsync(Nota nota);
        Task DeleteAsync(int id);
    }
}
