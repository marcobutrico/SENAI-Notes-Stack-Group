using OrganizedNotesAPI.Models;

namespace OrganizedNotesAPI.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllAsync();
        Task<Tag> GetByIdAsync(int id);
        Task AddAsync(Tag tag);
    }
}
