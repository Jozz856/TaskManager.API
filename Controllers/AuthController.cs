using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.API.Datos;
using TaskManager.API.DTOs;
using TaskManager.API.Modelos;


namespace TaskManager.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ContextoBaseDatos _context;
        private readonly IConfiguration _configuration;


        public AuthController(
            ContextoBaseDatos context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }



      
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var usuarioExiste = _context.Usuarios
                .FirstOrDefault(x => x.NombreUsuario == dto.NombreUsuario);

            if (usuarioExiste != null)
            {
                return BadRequest("El usuario ya existe");
            }

            var usuario = new Usuario
            {
                NombreUsuario = dto.NombreUsuario,
                Password = dto.Password
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Ok(new
            {
                mensaje = "Usuario registrado correctamente"
            });
        }



        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x =>
                x.NombreUsuario == dto.NombreUsuario &&
                x.Password == dto.Password
            );

            if (usuario == null)
            {
                return Unauthorized("Usuario o contraseña incorrectos");
            }

            var claims = new[]
            {
              new Claim(
            ClaimTypes.Name,
            usuario.NombreUsuario
                )
                };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!
                )
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler()
                    .WriteToken(token)
            });
        }



        [HttpDelete("usuarios/{id}")]
        public IActionResult EliminarUsuario(int id)
        {

            var usuario = _context.Usuarios
                .FirstOrDefault(x => x.UsuarioId == id);



            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }



            _context.Usuarios.Remove(usuario);


            _context.SaveChanges();



            return Ok(new
            {
                mensaje = "Usuario eliminado correctamente"
            });

        }


        [HttpGet("usuarios")]
        public IActionResult ObtenerUsuarios()
        {
            var usuarios = _context.Usuarios
                .Select(x => new
                {
                    id = x.UsuarioId,
                    nombreUsuario = x.NombreUsuario
                })
                .ToList();

            return Ok(usuarios);
        }


        [HttpPut("usuarios/{id}")]
        public IActionResult ActualizarUsuario(int id, RegisterDto dto)
        {

            var usuario = _context.Usuarios
                .FirstOrDefault(x => x.UsuarioId == id);



            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }



            usuario.NombreUsuario = dto.NombreUsuario;


            if (!string.IsNullOrEmpty(dto.Password))
            {
                usuario.Password = dto.Password;
            }



            _context.SaveChanges();



            return Ok(new
            {
                mensaje = "Usuario actualizado correctamente"
            });


        }
    }
}