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

    public class UsuarioController : ControllerBase
    {
        private INoteUserRepository _usuarioRepository;

        public UsuarioController(INoteUserRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        //----------------------------------------------
        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_usuarioRepository.ListarTodos());
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_usuarioRepository.ObterPorId(id));
        }



        /// <summary>
        /// Fazer login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            var usuario = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Password);

            if (usuario == null)
            {
                return Unauthorized("Email ou Senha invalidos!");
            }

            var tokenService = new TokenService();

            var token = tokenService.GenerateToken(usuario.Email);

            return Ok(new
            {
                token,
                usuario
            });
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(NotesUser usuario)
        {
            _usuarioRepository.CadastrarUsuario(usuario);

            return Created();
        }


    }
}




//    //----------------------------------------------

//    [HttpPost("login")]
//    public IActionResult Login([FromBody] LoginRequestDto loginDto)
//    {
//        var user = _userRepository.GetByEmail(loginDto.Email);
//        if (user == null)
//            return Unauthorized("Usuário ou senha inválidos.");

//        if (!_passwordService.VerifyPassword(user, loginDto.Password))
//            return Unauthorized("Usuário ou senha inválidos.");

//        var tokenService = new TokenServiceBase();
//        var token = tokenService.GenerateToken(user.Email);

//        var response = new LoginResponseDto
//        {
//            Token = token,
//            Id = user.IdUser,
//            Email = user.Email
//        };

//        return Ok(response);
//    }

//    //---------------------

//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetUserById(int id)
//    {
//        var user = await _userRepository.GetByIdAsync(id);
//        if (user == null)
//        {
//            return NotFound();
//        }
//        return Ok(user);
//    }

//    [HttpPost]
//    public async Task<IActionResult> CreateUser(NotesUser user)
//    {
//        if (user == null)
//        {
//            return BadRequest("Object Users cannot be null.");
//        }

//        await _userRepository.CreateUserAsync(user);
//        return CreatedAtAction(nameof(GetUserById), new { id = user.IdUser }, user);
//    }

//    [HttpDelete("{idUser}")]
//    public async Task<IActionResult> Deletar(int idUser)
//    {
//        try
//        {
//            await _userRepository.DeleteUserAsync(idUser);

//            return NoContent();
//        }
//        catch (Exception ex)
//        {
//            return NotFound("Usuario não encontrado!");
//        }
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> Editar(int id, NotesUser user)
//    {
//        try
//        {
//            await _userRepository.UpdateUserAsync(user, id);
//            return Ok(user);
//        }
//        catch (Exception ex)
//        {
//            return NotFound(ex);
//        }
//    }
//}
//}