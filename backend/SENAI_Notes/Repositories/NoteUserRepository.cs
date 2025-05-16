using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SENAI_Notes.Context;
using SENAI_Notes.Controllers;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Repositories
{
    public class NoteUserRepository : INoteUserRepository
    {

        private readonly SenaiNotesContext _context;

        public NoteUserRepository(SenaiNotesContext context)
        {
            _context = context;
        }

        public async Task<NotesUser> CreateUserAsync(NotesUser user)
        {
            //var passwordService = new PasswordService();

            NotesUser userCadastrar = new NotesUser
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserThemePreferences = user.UserThemePreferences,
                UserFontPreferences = user.UserFontPreferences,
                CreatedAt = DateTime.Now
            };

            // clienteCadastrar.Senha = passwordService.HashPassword(clienteCadastrar);

            await _context.NotesUsers.AddAsync(userCadastrar);
            // 2 - Salvo a Alteração
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(int idUser)
        {
            var userEncontrado = _context.NotesUsers.Find(idUser);

            if (userEncontrado == null)
            {
                throw new ArgumentNullException("Usuario não encontrado!");
            }

            _context.NotesUsers.Remove(userEncontrado);

            await _context.SaveChangesAsync();
        }

        public async Task<List<NotesUser>> GetAllUsers()
        {
            return await _context.NotesUsers.ToListAsync();
        }

        public async Task<NotesUser> GetByIdAsync(int idUser)
        {
            return await _context.NotesUsers.FindAsync(idUser);
        }



        public async Task UpdateUserAsync(int idUser, NotesUser usuario)
        {
            //var passwordService = new PasswordService();
            var userFound = _context.NotesUsers.Find(idUser);

            if (userFound == null)
            {
                throw new ArgumentNullException("Usuario não encontrado!");
            }

            userFound.Name = usuario.Name;
            userFound.Email = usuario.Email;
            userFound.Password = usuario.Password;
            userFound.UserThemePreferences = usuario.UserThemePreferences;
            userFound.UserFontPreferences = usuario.UserFontPreferences;

           // clienteEncontrado.Senha = passwordService.HashPassword(clienteEncontrado);

            await _context.SaveChangesAsync();

      }





            //public Task UpdateUserAsync(NotesUser usuario, int idUser)
            //{
            //    throw new NotImplementedException();
            //}


        public NotesUser? BuscarPorEmailSenha(string email, string senha)
        {
            var userEncontrado = _context.NotesUsers.FirstOrDefault(u => u.Email == email);

            //caso nao encontre, retorna nulo
            if (userEncontrado == null)
                return null;

            // var passwordService = new PasswordService();
            //verificar se a Senha do usuario gera o mesmo hash
            // var resultado = passwordService.VerificarSenha(clienteEncontrado, senha);
            //if (resultado == true) return clienteEncontrado;
            return null;

        }


    }
}
