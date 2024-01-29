using AutoMapper;
using DTO.CitasDTO;
using DTO.VentasDTO;
using Microsoft.AspNetCore.Mvc;
using Models.Módulo_Citas;
using Models.Módulo_Ventas;
using Presentacion.Repository;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVentasRepository _ventasRepository;

        public VentasController(IMapper mapper, IVentasRepository ventasRepository)
        {

            _mapper = mapper;
            _ventasRepository = ventasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                var listVentas = await _ventasRepository.GetListVentas();

                var listVentasDto = _mapper.Map<IEnumerable<VentasDTO>>(listVentas);

                return Ok(listVentasDto);
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
                var venta = await _ventasRepository.GetVentas(id);
                if (venta == null)
                {
                    return NotFound();
                }

                var ventasDTO = _mapper.Map<VentasDTO>(venta);

                return Ok(ventasDTO);
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
                var venta = await _ventasRepository.GetVentas(id);
                if (venta == null)
                {
                    return NotFound();
                }

                await _ventasRepository.DeleteVenta(venta);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post(VentasDTO ventasDto)
        {
            try
            {

                var ventas = _mapper.Map<Ventas>(ventasDto);

                ventas.fechaCreacion = DateTime.Now;

                ventas = await _ventasRepository.AddVenta(ventas);

                var ventasItemDto = _mapper.Map<VentasDTO>(ventas);

                return CreatedAtAction("Get", new { id = ventasItemDto.Id }, ventasItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, VentasDTO ventasDto)
        {
            try
            {
                var ventasItem = await _ventasRepository.GetVentas(id);

                if (ventasItem == null)
                {
                    return NotFound();
                }
                ventasItem.fechaRegistro = ventasDto.fechaRegistro;
                ventasItem.nombreCliente = ventasDto.nombreCliente;
                ventasItem.nombreProducto = ventasDto.nombreProducto;
                ventasItem.cantidad = ventasDto.cantidad;
                ventasItem.metodoPago = ventasDto.metodoPago;

                await _ventasRepository.UpdateVenta(ventasItem);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
