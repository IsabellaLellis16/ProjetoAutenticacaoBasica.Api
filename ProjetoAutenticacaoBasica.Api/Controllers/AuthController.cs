using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAutenticacaoBasica.Api.Models;
using ProjetoAutenticacaoBasica.Api.Models.DTOs;
using ProjetoAutenticacaoBasica.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAutenticacaoBasica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto resgisterDto)
        {
            var novoUsuario = new Usuario
            {
                Nome = resgisterDto.Nome,
                Username = resgisterDto.Username,
                Password = resgisterDto.Password,
                CreatedAt = DateTime.Now
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return Ok("Usuário registrado com sucesso!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == loginDto.Username && u.Password == loginDto.Password);

            if (usuario == null)
            {
                return NotFound("Credenciais inválidas!");
            }

            return Ok(new { Nome = usuario.Nome });
        }
    }
}
