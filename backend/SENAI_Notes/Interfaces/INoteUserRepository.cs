using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    public interface INoteUserRepository
    {
        Task<List<NotesUser>> GetAllUsers();
        Task<NotesUser> GetByIdAsync(int idUser);
        Task CreateUserAsync(NotesUser usuario);
        //Task UpdateUserAsync(NotesUser usuario, int idUser);
        //Task DeleteUserAsync(int idUser);
        //Task<NotesUser> GetByEmailnPasswordAsync(string Email, string Password);
        //Task GetByName(string Nome);
    }
}
