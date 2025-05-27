using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    public interface INoteUserRepository : IGenericRepository<NotesUser>
    {
        void CadastrarUsuario(NotesUser usuario);
        NotesUser? BuscarPorEmailSenha(string email, string password);
    }

}

