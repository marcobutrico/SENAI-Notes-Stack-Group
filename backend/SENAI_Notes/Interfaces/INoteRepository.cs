using SENAI_Notes.Models;
using SENAI_Notes.Repositories;
using SENAI_Notes.ViewModels;

namespace SENAI_Notes.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllAsync(int Id);
        List<ListTagViewModel> ListAllNotes();
        Task<Note> GetByIdAsync(int id);
        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(int id);
        CadastroNoteDto? CadastrarAnotacao(CadastroNoteDto anotacao);
    }
}
