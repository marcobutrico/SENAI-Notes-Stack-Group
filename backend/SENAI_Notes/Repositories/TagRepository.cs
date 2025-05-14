using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Repositories
{
    public class TagRepository : ITagRepository
    {
        public Task AddAsync(Tag tag)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
