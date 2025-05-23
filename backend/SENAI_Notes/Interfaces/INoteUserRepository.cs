﻿using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    public interface INoteUserRepository
    {
        Task<List<NotesUser>> GetAllUsers();
        Task<NotesUser> GetByIdAsync(int idUser);
        Task<NotesUser> CreateUserAsync(NotesUser user);
        Task DeleteUserAsync(int idUser);

        Task UpdateUserAsync(NotesUser usuario, int idUser);

        NotesUser GetByEmail(string email);
    }
}
