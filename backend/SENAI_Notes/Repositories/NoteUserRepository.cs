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

        public async Task<List<NotesUser>> GetAllUsers()
        {
            return await _context.NotesUsers.ToListAsync();
        }

        public async Task<NotesUser> GetByIdAsync(int idUser)
        {
            return await _context.NotesUsers.FindAsync(idUser);
        }


        public Task CreateUserAsync(NotesUser usuario)
        {
            {
                NotesUser createUser = new NotesUser
                {
                    Name = createUser.Name,
                    Email = createUser.Email,
                    Password = createUser.Password,
                    UserThemePreferences = createUser.UserThemePreferences,
                    UserFontPreferences = createUser.UserFontPreferences,
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),

                };
                _context.NotesUsers.Add(usuario);
                await _context.SaveChangesAsync();
            }
        }

        //public Task UpdateUserAsync(NoteUser usuario, int idUser)
        //{
        //    var foundUser = await _context.NotesUsers.FindAsync(idUser);

        //    if (foundUser == null)
        //    {
        //        throw new ArgumentNullException("User not found!");
        //    }

        //    foundUser.Name = usuario.Name;
        //    foundUser.Email = usuario.Email;
        //    foundUser.Password = usuario.Password;
        //    foundUser.UserThemePreferences = usuario.UserThemePreferences;
        //    foundUser.UserFontPreferences = usuario.UserFontPreferences;
        //    foundUser.CreatedAt = usuario.CreatedAt;

        //    await _context.SaveChangesAsync();
        //}


        //public Task DeleteUserAsync(int idUser)
        //{
        //    var foundUser = await _context.NotesUsers.FindAsync(idUser);

        //    if (foundUser == null)
        //    {
        //        throw new ArgumentNullException("User not found!");
        //    }

        //    _context.NotesUsers.Remove(foundUser);
        //    await _context.SaveChangesAsync();
        //}

        //public Task UpdateUserAsync(NotesUser usuario, int idUser)
        //{
        //    throw new NotImplementedException();
        //}


        //public Task<NotesUser> GetByEmailnPasswordAsync(string Email, string Password)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task GetByName(string nome)
        //{
        //    //Where - traz todos que atendem uma condicao
        //    //var listaClientes = _context.Clientes.Where(c => c.NomeCompleto == nome).ToList();
        //    var listUsers = _context.NotesUsers.Where(u => u.Name.Contains(nome)).ToList();

        //    return listUsers;
        //}


    }
}
