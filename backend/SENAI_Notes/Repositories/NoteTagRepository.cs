using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Repositories
{
    public class NoteTagRepository : INoteTagRepository
    {
        private readonly SENAI_NotesContext _context;
        public NoteTagRepository(SENAI_NotesContext context) 
        {
            _context = context;
        }

        public async Task AddNotetagAsync(Notetag noteTag)
        {
            await _context.Notetag.AddAsync(noteTag);
        }

        public async Task<Notetag> GetAllNoteTagsAsync() 
        {
            return await _context.Notetag.ToListAsync();
        }

        public async Task<Notetag> GetNoteTagByIdAsync(int id)
        {
            return await _context.Notetag.FirstOrDefaultAsync(nt => nt.IdNoteTag == id);
        }

        public async Task RemoveNoteTagAsync(int id)
        {
            var noteTag = await _context.Notetag.FirstOrDefaultAsync(nt => nt.IdNoteTag == id);
            if (noteTag != null)
            {
                _context.Notetag.Remove(noteTag);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
