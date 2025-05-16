using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        // GET: api/Tag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
        {
            var tags = await _tagRepository.GetAllAsync();
            return Ok(tags);
        }

        // GET: api/Tag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        // POST: api/Tag
        [HttpPost]
        public async Task<ActionResult<Tag>> CreateTag(Tag tag)
        {
            await _tagRepository.AddAsync(tag);
            return CreatedAtAction(nameof(GetTag), new { id = tag.IdTag }, tag);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateTag(int id, Tag tag)
        {
            if (id != tag.IdTag)
            {
                return BadRequest();
            }

            var existingTag = await _tagRepository.GetByIdAsync(id);
            if (existingTag == null)
            {
                return NotFound();
            }

            await _tagRepository.UpdateAsync(id, tag);
            return NoContent();
        }



        // DELETE: api/Tag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            await _tagRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
  
