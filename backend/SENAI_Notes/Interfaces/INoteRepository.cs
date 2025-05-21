using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllAsync(int Id);
        Task<Note> GetByIdAsync(int id);
        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(int id);

    }
}
