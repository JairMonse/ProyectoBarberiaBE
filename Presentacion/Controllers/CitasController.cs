using AutoMapper;
using DTO.CitasDTO;
using Microsoft.AspNetCore.Mvc;
using Models.Módulo_Citas;
using Presentacion.Repository;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICitasRepository _citasRepository;

        public CitaController(IMapper mapper, ICitasRepository citasRepository)
        {

            _mapper = mapper;
            _citasRepository = citasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                var listCitas = await _citasRepository.GetListCitas();

                var listCitasDto = _mapper.Map<IEnumerable<CitasDTO>>(listCitas);

                return Ok(listCitasDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var cita = await _citasRepository.GetCitas(id);
                if (cita == null)
                {
                    return NotFound();
                }

                var citasDTO = _mapper.Map<CitasDTO>(cita);

                return Ok(citasDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cita = await _citasRepository.GetCitas(id);
                if (cita == null)
                {
                    return NotFound();
                }

                await _citasRepository.DeleteCita(cita);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post(CitasDTO citasDto)
        {
            try
            {

                var citas = _mapper.Map<Citas>(citasDto);

                citas.fechaCreacion = DateTime.Now;

                citas = await _citasRepository.AddCita(citas);

                var citasItemDto = _mapper.Map<CitasDTO>(citas);

                return CreatedAtAction("Get", new { id = citasItemDto.Id }, citasItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CitasDTO citasDto)
        {
            try
            {
                var citaItem = await _citasRepository.GetCitas(id);

                if (citaItem == null)
                {
                    return NotFound();
                }

                citaItem.fechaCita = citasDto.fechaCita;
                citaItem.hora = citasDto.hora;
                citaItem.nombreBarbero = citasDto.nombreBarbero;
                citaItem.nombreCliente = citasDto.nombreCliente;
                citaItem.telefono = citasDto.telefono;
                citaItem.correoE = citasDto.correoE;
                citaItem.tipoServicio = citasDto.tipoServicio; 
                citaItem.fechaCreacion = DateTime.Now;

                await _citasRepository.UpdateCita(citaItem);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
