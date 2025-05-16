using Microsoft.EntityFrameworkCore;
using SENAI_Notes.Context;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Repositories
{
    public class TagRepository : ITagRepository
    {
        private SenaiNotesContext _context;


        public TagRepository(SenaiNotesContext context) => _context = context;

        public async Task<List<Tag>> GetAllAsync() => await _context.Tags.ToListAsync();

        public async Task<Tag> GetByIdAsync(int id) => await _context.Tags.FindAsync(id);

        public async Task AddAsync(Tag tag)
        {
            object value = _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(int id, Tag tag)
        {
            //var passwordService = new PasswordService();
            var foundTag = _context.Tags.Find(id);

            if (foundTag == null)
            {
                throw new ArgumentNullException("Tag not found!");
            }

            // Atualize as propriedades do cliente com o DTO
            foundTag.Name = tag.Name;

            //clienteEncontrado.Senha = passwordService.HashPassword(clienteEncontrado);

            _context.SaveChanges();

        }

        public async Task DeleteAsync(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }
    }
}

