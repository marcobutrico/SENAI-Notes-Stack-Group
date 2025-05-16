using Microsoft.EntityFrameworkCore;
using SENAI_Notes.Context;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly SenaiNotesContext _context;

        public NoteRepository(SenaiNotesContext context)
        {
            _context = context;
        }

        public async Task<List<Note>> GetAllAsync(int IdUser)
        {
            return await _context.Notes.Where(n => n.IdUser == IdUser).ToListAsync();
        }

        public async Task<Note> GetByIdAsync(int idNote)
        {
            return await _context.Notes.FindAsync(idNote);
        }

        public async Task AddAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }
    }
}


       