using AuthApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PRACTICA08092025.DTOs.UsuariosDTOs;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] UsuariosRegistroDTO dto)
        {
            var result = await _authService.RegistrarAsync(dto);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuariosLoginDTO dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (result == null) return Unauthorized("Credenciales inválidas");
            return Ok(result);
        }
    }
}