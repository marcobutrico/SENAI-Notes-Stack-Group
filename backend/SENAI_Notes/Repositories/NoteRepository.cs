using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Repositories
{
    public class NoteRepository : INoteRepository
    {
        public Task AddAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Note>> GetAllAsync(int IdUser)
        {
            throw new NotImplementedException();
        }

        public Task<Note> GetByIdAsync(int idNote)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
