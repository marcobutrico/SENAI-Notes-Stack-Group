using Microsoft.AspNetCore.Identity;
using SENAI_Notes.Models; 

namespace SENAI_Notes.Services
{
    public class PasswordService
    {
        private readonly PasswordHasher<NotesUser> _passwordHasher = new();

        public string HashPassword(NotesUser usuario)
        {
            return _passwordHasher.HashPassword(usuario, usuario.Password);
        }

        public bool VerificarSenha(NotesUser usuario, string senhaInformada)
        {
            var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, senhaInformada);

            return resultado == PasswordVerificationResult.Success;
        }
    }
}