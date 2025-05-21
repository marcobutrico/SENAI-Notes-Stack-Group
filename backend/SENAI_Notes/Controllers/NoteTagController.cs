using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;
using SENAI_Notes.Repositories;

namespace SENAI_Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteTagController : ControllerBase
    {
        private readonly INoteTagRepository _noteTagRepository;

        public NoteTagController(INoteTagRepository noteTagRepository)
        {
            _noteTagRepository = noteTagRepository;
        }
        // GET: api/NoteTag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notetag>>> GetNoteTags()
        {
            var noteTags = await _noteTagRepository.GetAllNoteTagsAsync();
            return Ok(noteTags);
        }

        // GET: api/NoteTag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notetag>> GetNoteTag(int id)
        {
            var noteTag = await _noteTagRepository.GetNoteTagByIdAsync(id);

            if (noteTag == null)
            {
                return NotFound();
            }

            return Ok(noteTag);
        }

        // POST: api/NoteTag
        [HttpPost]
        public async Task<ActionResult<Notetag>> PostNoteTag(Notetag noteTag)
        {
            await _noteTagRepository.AddNotetagAsync(noteTag);
            await _noteTagRepository.SaveAsync();

            return CreatedAtAction("GetNoteTag", new { id = noteTag.IdNoteTag }, noteTag);
        }

        // DELETE: api/NoteTag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteTag(int id)
        {
            var noteTag = await _noteTagRepository.GetNoteTagByIdAsync(id);
            if (noteTag == null)
            {
                return NotFound();
            }

            await _noteTagRepository.RemoveNoteTagAsync(id);
            await _noteTagRepository.SaveAsync();

            return NoContent();
        }
    }
}