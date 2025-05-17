using SENAI_Notes.Models;
using System.Collections.Generic; // Add this for IEnumerable

namespace SENAI_Notes.Interfaces
{
    public interface INoteTagRepository
    {
        Task<IEnumerable<Notetag>> GetAllNoteTagsAsync(); // Change to IEnumerable
        Task<Notetag> GetNoteTagByIdAsync(int id);
        Task AddNotetagAsync(Notetag noteTag);
        Task UpdateNotetagAsync(Notetag noteTag); // Add Update method
        Task RemoveNoteTagAsync(int id);
        Task SaveAsync();
    }
}