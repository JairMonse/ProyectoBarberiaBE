using AutoMapper;
using DTO.BarberoDTO;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentacion.Infrastructure;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombosController : Controller
    {

        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;

        public CombosController(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("especialidades")]
        public async Task<ActionResult<List<EspecialidadDTO>>> GetEspecialidades()
        {
            try
            {
                var listEspecialidades = await _context.Especialidades.ToListAsync();
                var listEspecialidadesDto = _mapper.Map<List<EspecialidadDTO>>(listEspecialidades);
                return Ok(listEspecialidadesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("jornadas")]
        public async Task<ActionResult<List<jornadasDTO>>> GetJornadas()
        {
            try
            {
                var listJornadas = await _context.Jornadas.Where(x => x.Estado).ToListAsync();
                var listJornadasDto = _mapper.Map<List<jornadasDTO>>(listJornadas);
                return Ok(listJornadasDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
