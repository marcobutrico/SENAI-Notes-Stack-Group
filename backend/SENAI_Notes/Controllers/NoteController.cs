using Microsoft.AspNetCore.Mvc;
using SENAI_Notes.Models;
using SENAI_Notes.Interfaces;


namespace SENAI_Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // GET: api/Note/User/5
        [HttpGet("User/{idUser}")]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotesByUser(int idUser)
        {
            try
            {
                var notes = await _noteRepository.GetAllAsync(idUser);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Note/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            try
            {
                var note = await _noteRepository.GetByIdAsync(id);

                if (note == null)
                {
                    return NotFound();
                }

                return Ok(note);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Note
        [HttpPost]
        public async Task<ActionResult<Note>> CreateNote(Note note)
        {
            try
            {
                if (note == null)
                {
                    return BadRequest("Note object is null");
                }

                // Set CreatedAt and UpdatedAt
                note.CreatedAt = DateTime.UtcNow;
                note.UpdatedAt = DateTime.UtcNow;


                await _noteRepository.AddAsync(note);

                return CreatedAtAction(nameof(GetNote), new { id = note.IdNote }, note);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Note/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, Note note)
        {
            try
            {
                if (note == null)
                {
                    return BadRequest("Note object is null");
                }

                if (id != note.IdNote)
                {
                    return BadRequest("Id in the request body does not match the route id");
                }

                var existingNote = await _noteRepository.GetByIdAsync(id);
                if (existingNote == null)
                {
                    return NotFound();
                }

                // Update properties
                existingNote.Title = note.Title;
                existingNote.Content = note.Content;
                existingNote.ImageUrl = note.ImageUrl;
                existingNote.IsFavorite = note.IsFavorite;
                existingNote.IsArchived = note.IsArchived;
                existingNote.UpdatedAt = DateTime.UtcNow; // Update UpdatedAt

                await _noteRepository.UpdateAsync(existingNote);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Note/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            try
            {
                var note = await _noteRepository.GetByIdAsync(id);
                if (note == null)
                {
                    return NotFound();
                }

                await _noteRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}