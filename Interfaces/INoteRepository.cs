using SENAI_Notes.Models;
using SENAI_Notes.DTO;
using SENAI_Notes.ViewModels;


namespace SENAI_Notes.Interfaces
{
    public interface INoteRepository : IGenericRepository<Note>
    {
        List<ListarAnotacaoViewModel> ListarTodosInclude();
        Note? ArquivarAnotacao(int id);
        CadastroAnotacaoDto? CadastrarAnotacao(CadastroAnotacaoDto anotacao);
        List<Note> BuscarPorUsuario(int id);
    }
}
