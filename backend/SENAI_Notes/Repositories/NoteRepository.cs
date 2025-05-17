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
            return await _context.Notes
                .Where(n => n.IdUser == IdUser)
                .ToListAsync();
        }

        public async Task<Note?> GetByIdAsync(int idNote)
        {
            return await _context.Notes.FindAsync(idNote);
        }

        public async Task AddAsync(Note note)
        {
            note.CreatedAt = DateTime.UtcNow;
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note note)
        {
            var existingNote = await _context.Notes.FindAsync(note.IdNote);
            if (existingNote == null)
            {
                throw new KeyNotFoundException($"Nota com ID {note.IdNote} não encontrada.");
            }

            existingNote.Title = note.Title;
            existingNote.Content = note.Content;
            existingNote.ImageUrl = note.ImageUrl;
            existingNote.IsFavorite = note.IsFavorite;
            existingNote.IsArchived = note.IsArchived;
            existingNote.UpdatedAt = DateTime.UtcNow;

            _context.Notes.Update(existingNote);
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
        }

        public async Task<bool> NoteExistsAsync(int id)
        {
            return await _context.Notes.AnyAsync(n => n.IdNote == id);
        }
    }
}


