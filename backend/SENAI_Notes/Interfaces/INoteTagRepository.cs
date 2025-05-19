using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    public interface INoteTagRepository
    {
        Task <Notetag> GetAllNoteTagsAsync();
        Task <Notetag> GetNoteTagByIdAsync(int id);
        Task AddNotetagAsync(Notetag noteTag);
        Task RemoveNoteTagAsync(int id);
        Task SaveAsync();

    }
}
