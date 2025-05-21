using Microsoft.AspNetCore.Identity;
using SENAI_Notes.Models; 

namespace SENAI_Notes.Services
{
    public class PasswordService
    {
        private readonly PasswordHasher<NotesUser> _hasher = new();

        public string HashPassword(NotesUser user)
        {
            return _hasher.HashPassword(user, user.Password);
        }

        public bool VerifyPassword(NotesUser user, string providedPassword)
        {
            var result = _hasher.VerifyHashedPassword(user, user.Password, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}