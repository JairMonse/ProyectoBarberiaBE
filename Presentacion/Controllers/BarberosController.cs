using AutoMapper;
using DTO.BarberoDTO;
using Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentacion.Infrastructure;
using Shared;
using System.Transactions;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberosController : Controller
    {

        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;

        public BarberosController(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("page")]
        public async Task<ActionResult<List<BarberoPageDTO>>> GetBarberosPage()
        {
            try
            {
                var barberos = await _context.Barberos
                    .Include(b => b.Especialidad)
                    .Include(b => b.Jornada)
                    .Where(b => b.Estado)
                    .Select(b => new BarberoPageDTO
                    {
                        Nombres = b.Nombres,
                        Telefono = b.Telefono,
                        Experiencia = b.Experiencia,
                        Descripcion = b.Especialidad.Descripcion,
                        Disponibilidad = b.Jornada.disponibilidad,
                        ImageName = b.ImageName
                    })
                    .ToListAsync();

                var listBarberosDto = _mapper.Map<List<BarberoPageDTO>>(barberos);

                return Ok(listBarberosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpGet("admin")]
        public async Task<ActionResult<List<BarberoGetDTO>>> GetBarberosAdmin()
        {
            try
            {
                var barberos = await _context.Barberos
                    .Include(b => b.Especialidad)
                    .Include(b => b.Jornada)
                    .Where(b => b.Estado)
                    .Select(b => new BarberoGetDTO
                    {
                        Id = b.Id,
                        Nombres = b.Nombres,
                        Telefono = b.Telefono,
                        Experiencia = b.Experiencia,
                        EspecialidadId = b.EspecialidadId,
                        Descripcion = b.Especialidad.Descripcion,
                        JornadaId = b.JornadaId,
                        Disponibilidad = b.Jornada.disponibilidad,
                        ImageName = b.ImageName,
                    })
                    .ToListAsync();

                var listBarberosDto = _mapper.Map<List<BarberoGetDTO>>(barberos);

                return Ok(listBarberosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Respuesta>> PostBarbero([FromBody] BarberoPostDTO nuevo)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var idEspecialidad = await _context.Especialidades.FindAsync(nuevo.EspecialidadId);
                    if (idEspecialidad is null)
                    {
                        return NotFound(new Respuesta(false, "Especialidad no existe"));
                    }

                    var idJornada = await _context.Jornadas.FindAsync(nuevo.JornadaId);
                    if (idJornada is null)
                    {
                        return NotFound(new Respuesta(false, "Jornada no existe"));
                    }

                    var barberoNew = _mapper.Map<Barbero>(nuevo);
                    _context.Barberos.Add(barberoNew);
                    await _context.SaveChangesAsync();

                    scope.Complete();

                    return Ok(new Respuesta(true, "Barbero ingresado con éxito."));
                }              
                catch (Exception ex)
                {                   
                    return BadRequest(new Respuesta(false, "Ha ocurrido un error"));
                }
            }
        }


        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Respuesta>> PutBarbero([FromBody] BarberoPutDTO nuevo)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var barberoExiste = await _context.Barberos
                        .Where(x => x.Id == nuevo.Id && x.Estado)
                        .FirstOrDefaultAsync();
                    if (barberoExiste is null)
                    {
                        return NotFound(new Respuesta(false, "Barbero no existe"));
                    }

                    var idEspecialidad = await _context.Especialidades.FindAsync(nuevo.EspecialidadId);
                    if (idEspecialidad is null)
                    {
                        return NotFound(new Respuesta(false, "Especialidad no existe"));
                    }

                    var idJornada = await _context.Jornadas.FindAsync(nuevo.JornadaId);
                    if (idJornada is null)
                    {
                        return NotFound(new Respuesta(false, "Jornada no existe"));
                    }
                    
                    barberoExiste.Nombres = nuevo.Nombres;
                    barberoExiste.Telefono = nuevo.Telefono;
                    barberoExiste.Experiencia = nuevo.Experiencia;
                    barberoExiste.ImageName = nuevo.ImageName;
                    barberoExiste.EspecialidadId = nuevo.EspecialidadId;
                    barberoExiste.JornadaId = nuevo.JornadaId;
                    barberoExiste.Estado = true;
                    await _context.SaveChangesAsync();

                    scope.Complete();

                    return Ok(new Respuesta(true, "Barbero actualizado con éxito."));
                }
                catch (Exception ex)
                {
                    return BadRequest(new Respuesta(false, "Ha ocurrido un error"));
                }
            }
        }


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Respuesta>> DeleteBarbero([FromRoute] long id)
        {
            try
            {
                var barberoExiste = await _context.Barberos
                    .Where(x => x.Id == id && x.Estado)
                    .FirstOrDefaultAsync();

                if (barberoExiste is null)
                {
                    return NotFound(new Respuesta(false, "Barbero no existe"));
                }

                barberoExiste.Estado = false;
                await _context.SaveChangesAsync();

                return Ok(new Respuesta(true, "Barbero eliminado con éxito."));
            }
            catch (Exception ex)
            {
                return BadRequest(new Respuesta(false, ex.Message));
            }
        }


    }

}
