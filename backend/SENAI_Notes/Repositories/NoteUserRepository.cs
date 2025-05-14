using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Repositories
{
    public class NoteUserRepository : INoteUserRepository
    {
        public Task AddAsync(NotesUser usuario)
        {
            throw new NotImplementedException();
        }

        public Task<NotesUser> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<NotesUser> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
