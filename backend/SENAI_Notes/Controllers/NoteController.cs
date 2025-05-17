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
=======
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

>>>>>>> ca9691703ad8d8a627795f525a620eff3103c7b7
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            try
            {
<<<<<<< HEAD
                var note = await _noteRepository.GetByIdAsync(id);
                if (note == null)
=======
                if (!await _noteRepo.NoteExistsAsync(id))
>>>>>>> ca9691703ad8d8a627795f525a620eff3103c7b7
                {
                    return NotFound();
                }

<<<<<<< HEAD
                await _noteRepository.DeleteAsync(id);

=======
                await _noteRepo.DeleteAsync(id);
>>>>>>> ca9691703ad8d8a627795f525a620eff3103c7b7
                return NoContent();
            }
            catch (Exception ex)
            {
<<<<<<< HEAD
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir nota: {ex.Message}");
            }
        }
    }
}

