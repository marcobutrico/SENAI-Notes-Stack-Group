using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepo;

        public NoteController(INoteRepository noteRepo)
        {
            _noteRepo = noteRepo ?? throw new ArgumentNullException(nameof(noteRepo));
        }

        [HttpGet("users/{userId}")]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotesByUserId(int userId)
        {
            try
            {
                var notes = await _noteRepo.GetAllAsync(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter notas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNoteById(int id)
        {
            try
            {
                var note = await _noteRepo.GetByIdAsync(id);
                if (note == null)
                {
                    return NotFound();
                }
                return Ok(note);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter nota: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Note>> CreateNote([FromBody] Note note)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _noteRepo.AddAsync(note);
                return CreatedAtAction(nameof(GetNoteById), new { id = note.IdNote }, note);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao criar nota: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromBody] Note note)
        {
            try
            {
                if (id != note.IdNote)
                {
                    return BadRequest("O ID da nota na rota deve corresponder ao ID no corpo da requisição.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!await _noteRepo.NoteExistsAsync(id))
                {
                    return NotFound();
                }

                await _noteRepo.UpdateAsync(note);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar nota: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            try
            {
                if (!await _noteRepo.NoteExistsAsync(id))
                {
                    return NotFound();
                }

                await _noteRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir nota: {ex.Message}");
            }
        }
    }
}
