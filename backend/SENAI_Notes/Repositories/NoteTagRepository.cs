using SENAI_Notes.Context;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;
using Microsoft.EntityFrameworkCore;

namespace SENAI_Notes.Repositories
{
    public class NoteTagRepository : INoteTagRepository
    {
        public Task AddNotetagAsync(Notetag noteTag)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notetag>> GetAllNoteTagsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Notetag?> GetNoteTagByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveNoteTagAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}