using System.Collections.Generic;
using System.Threading.Tasks;
using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    public interface INoteTagRepository
    {
        Task<IEnumerable<Notetag>> GetAllNoteTagsAsync();
        Task<Notetag?> GetNoteTagByIdAsync(int id);
        Task AddNotetagAsync(Notetag noteTag);
        Task RemoveNoteTagAsync(int id);
        Task SaveAsync();
    }
}