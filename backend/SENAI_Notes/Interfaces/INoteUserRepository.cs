using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    public interface INoteUserRepository
    {
        Task<NotesUser> GetByIdAsync(int id);
        Task<NotesUser> GetByEmailAsync(string email);
        Task AddAsync(NotesUser usuario);

    }
}
