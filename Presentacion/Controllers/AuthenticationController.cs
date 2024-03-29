﻿using DTO.UsuarioDTO;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Presentacion.Infrastructure;
using Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {

        private readonly IConfiguration Configuration;
        private readonly AplicationDbContext _context;

        public AuthenticationController(AplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }


        [HttpPost]
        public async Task<ActionResult> Login([FromBody] UsuarioCredencialesDTO usuario)
        {
            try
            {
                var usuarioExiste = await _context.Usuarios
                    .FirstOrDefaultAsync(
                    u => u.Username == usuario.Username && 
                    u.Password == usuario.Password);

                if (usuarioExiste is null)
                {
                    return Ok(new Respuesta(false, "Credenciales incorrectas"));
                }

                return Ok(JsonConvert.SerializeObject(CrearToken(usuarioExiste)));

            }
            catch (Exception ex)
            {
                return BadRequest(new Respuesta(false, ex.Message));
            }
        }



        private string CrearToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombres),
            };
            var appSettingsToken = Configuration.GetSection("AppSettings:Token").Value;
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
