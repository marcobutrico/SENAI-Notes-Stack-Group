using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllAsync();
        Task<Tag> GetByIdAsync(int id);
        Task AddAsync(Tag tag);
    }
}
