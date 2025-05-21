using Microsoft.AspNetCore.Mvc;
using SENAI_Notes.Models;
using SENAI_Notes.Services;
using SENAI_Notes.Repositories;
using SENAI_Notes.Interfaces;
using SENAI_Notes.DTO;

namespace SENAI_Notes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly INoteUserRepository _userRepository;
        private readonly PasswordService _passwordService;

        public AuthController(INoteUserRepository userRepository)
        {
            _userRepository = userRepository;
            _passwordService = new PasswordService();
        }

        //----------------------------------------------

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto loginDto)
        {
            var user = _userRepository.GetByEmail(loginDto.Email);
            if (user == null)
                return Unauthorized("Usuário ou senha inválidos.");

            if (!_passwordService.VerifyPassword(user, loginDto.Password))
                return Unauthorized("Usuário ou senha inválidos.");

            var tokenService = new TokenServiceBase();
            var token = tokenService.GenerateToken(user.Email);

            var response = new LoginResponseDto
            {
                Token = token,
                Id = user.IdUser,
                Email = user.Email
            };

            return Ok(response);
        }

        //---------------------

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

        [HttpDelete("{idUser}")]
        public async Task<IActionResult> Deletar(int idUser)
        {
            try
            {
                await _userRepository.DeleteUserAsync(idUser);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Usuario não encontrado!");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, NotesUser user)
        {
            try
            {
                await _userRepository.UpdateUserAsync(user, id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}