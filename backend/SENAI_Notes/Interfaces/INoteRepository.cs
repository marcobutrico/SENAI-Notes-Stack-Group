using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    public interface INoteRepository
    {

        Task<List<Note>> GetAllAsync(int IdUser);
        Task<Note?> GetByIdAsync(int idNote);
        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(int id);
        Task<bool> NoteExistsAsync(int id);
        Task<bool> NoteExistsAsync(int id);
        Task<bool> NoteExistsAsync(int id);
        Task<bool> NoteExistsAsync(int id);
    }
}