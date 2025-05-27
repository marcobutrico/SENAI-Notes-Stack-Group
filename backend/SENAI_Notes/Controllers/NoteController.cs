using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SENAI_Notes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _notaRepo;

        public NoteController(INoteRepository notaRepo)
        {
            _notaRepo = notaRepo;
        }

        //public Anotacao? ArquivarAnotacao (int id)
        //{
            //var anotacao =_notaRepo.Notes.Find(id);
            //if (anotacao == null) { return null; 
            ///Notes.NotesArquivada =!Notes.NotesArquivada;
                //_notaRepo.SaveChanges();
                //return anotacao;
          //}


        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetNotas(int idUser)
        {
            var notas = await _notaRepo.GetAllAsync(idUser, _notaRepo.GetTitleNote());
            return Ok(notas);
        }

        [HttpGet("nota/{id}")]
        public async Task<IActionResult> GetNota(int id)
        {
            var nota = await _notaRepo.GetByIdAsync(id);
            if (nota == null)
            {
                return NotFound();
            }
            return Ok(nota);
        }

        [HttpPost]
        [SwaggerOperation(
          Summary = "Arquiva uma Anotacao",
            Description = "Este endpoint arquiva uma anotacao com base no ID fornecido"
            )]
        public async Task<IActionResult> CreateNota([FromBody] Note nota)
        {
            await _notaRepo.AddAsync(nota);
            return CreatedAtAction(nameof(GetNota), new { id = nota.IdNote }, nota);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNota([FromBody] Note nota)
        {
            await _notaRepo.UpdateAsync(nota);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            await _notaRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}

