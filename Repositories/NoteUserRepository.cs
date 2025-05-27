using SENAI_Notes.Context;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;
using SENAI_Notes.Services;


namespace SENAI_Notes.Repositories
{
    public class NoteUserRepository : GenericRepository<NotesUser>, INoteUserRepository
    {

        public NoteUserRepository(SenaiNotesContext context) : base(context)
        {
        }

        /// <summary>
        /// Repository para cadastrar usuário implementando senha
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public void CadastrarUsuario(NotesUser usuario)
        {
            var passwordService = new PasswordService();

            usuario.Password = passwordService.HashPassword(usuario);

            _context.NotesUsers.Add(usuario);
            _context.SaveChanges();
        }


        //--------------------------------------------
        /// <summary>
        /// Repository: Busca usuário por email e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public NotesUser? BuscarPorEmailSenha(string email, string senha)
        {
            var usuario = _context.NotesUsers.FirstOrDefault(u => u.Email == email);

            if (usuario == null)
            {
                return null;
            }

            var passwordService = new PasswordService();

            var resultado = passwordService.VerificarSenha(usuario, senha);

            if (resultado == true) return usuario;

            return null;
        }
    }
}


