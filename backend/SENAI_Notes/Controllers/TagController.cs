using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class NoteTagController : ControllerBase
    //{
    //    private readonly INoteTagRepository _noteTagRepository;

    //    public NoteTagController(INoteTagRepository noteTagRepository)
    //    {
    //        _noteTagRepository = noteTagRepository;
    //    }

    //    // Get all NoteTags
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<NoteTag>>> GetNoteTags()
    //    {
    //        var noteTags = await _noteTagRepository.GetAllNoteTagsAsync();
    //        return Ok(noteTags);
    //    }

    //    // Get NoteTag by ID
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<NoteTag>> GetNoteTag(int id)
    //    {
    //        var noteTag = await _noteTagRepository.GetNoteTagByIdAsync(id);
    //        if (noteTag == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(noteTag);
    //    }

    //    // Create a new NoteTag
    //    [HttpPost]
    //    public async Task<ActionResult<NoteTag>> CreateNoteTag(NoteTag noteTag)
    //    {
    //        await _noteTagRepository.AddNoteTagAsync(noteTag);
    //        return CreatedAtAction(nameof(GetNoteTag), new { id = noteTag.IdNoteTag }, noteTag);
    //    }

    //    // Delete a NoteTag by ID
    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult> DeleteNoteTag(int id)
    //    {
    //        await _noteTagRepository.RemoveNoteTagAsync(id);
    //        return NoContent();
    //    }
    //}

}
