using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SENAI_Notes.DTO;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : ControllerBase
    {
        private readonly INoteRepository _repository;

        public NotasController(INoteRepository repository)
        {
            _repository = repository;
        }



        /// <summary>
        /// Listar todas as notas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            var dados = _repository.ListarTodosInclude();

            return Ok(dados);
        }


        [HttpPost]
        public IActionResult Cadastrar(CadastroAnotacaoDto anotacao)
        {
            

            _repository.CadastrarAnotacao(anotacao);

            return Created();
        }




    }
}

