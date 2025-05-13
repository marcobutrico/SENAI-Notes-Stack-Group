using Microsoft.AspNetCore.Mvc;
using OrganizedNotesAPI.Interfaces;
using OrganizedNotesAPI.Models;

namespace OrganizedNotesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : ControllerBase
    {
        private readonly INotaRepository _notaRepo;

        public NotasController(INotaRepository notaRepo) => _notaRepo = notaRepo;

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetNotas(int usuarioId) =>
            Ok(await _notaRepo.GetAllAsync(usuarioId));

        [HttpGet("nota/{id}")]
        public async Task<IActionResult> GetNota(int id) =>
            Ok(await _notaRepo.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateNota([FromBody] Nota nota)
        {
            await _notaRepo.AddAsync(nota);
            return Ok(nota);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNota([FromBody] Nota nota)
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
