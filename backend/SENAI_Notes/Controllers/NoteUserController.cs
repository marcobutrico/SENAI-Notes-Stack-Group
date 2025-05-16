using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesUserController : ControllerBase
    {
        private readonly INoteUserRepository _userRepository;

        public NotesUserController(INoteUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(NotesUser user)
        {
            if (user == null)
            {
                return BadRequest("Object Users cannot be null.");
            }

            await _userRepository.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.IdUser }, user);
        }

        // Deleta Produto por ID
        [HttpDelete("{idUser}")]
        public async Task<IActionResult> Deletar(int idUser)
        {
            try
            {
                await _userRepository.DeleteUserAsync(idUser);

                return NoContent();
            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound("Usuario não encontrado!");
            }
        }

        // Edita Produto por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, NotesUser user)
        {
            try
            {
                await _userRepository.UpdateUserAsync(id, user);
                return Ok(user);

            }
            // Caso dê erro
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }


    }
}