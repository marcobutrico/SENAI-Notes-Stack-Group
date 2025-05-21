using SENAI_Notes.Context;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;
using Microsoft.EntityFrameworkCore;

namespace SENAI_Notes.Repositories
{
    internal class NoteTagRepository : INoteTagRepository
    {
        public async Task<IEnumerable<Notetag>> GetAllNoteTagsAsync()
        {
            // Implementation here
            throw new NotImplementedException();
        }

        public async Task<Notetag?> GetNoteTagByIdAsync(int id)
        {
            // Implementation here
            throw new NotImplementedException();
        }

        public async Task AddNotetagAsync(Notetag noteTag)
        {
            // Implementation here
            throw new NotImplementedException();
        }

        public async Task RemoveNoteTagAsync(int id)
        {
            // Implementation here
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            // Implementation here
            throw new NotImplementedException();
        }
    }
}