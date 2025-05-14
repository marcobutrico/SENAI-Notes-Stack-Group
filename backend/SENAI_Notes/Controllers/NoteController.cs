using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _notaRepo;

        public NoteController(INoteRepository notaRepo) => _notaRepo = notaRepo;

        [HttpGet("{idNote}")]
        public async Task<IActionResult> GetNotas(int idNote) =>
            Ok(await _notaRepo.GetAllAsync(idNote));

        [HttpGet("nota/{id}")]
        public async Task<IActionResult> GetNota(int id) =>
            Ok(await _notaRepo.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateNota([FromBody] Note nota)
        {
            await _notaRepo.AddAsync(nota);
            return Ok(nota);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNota([FromBody] Note nota)
        {
            await _notaRepo.UpdateAsync(nota);
            return Ok(nota);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            await _notaRepo.DeleteAsync(id);
            return Ok();
        }
    }
}

