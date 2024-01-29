using AutoMapper;
using DTO.CarritoDTO;
using DTO.CitasDTO;
using Microsoft.AspNetCore.Mvc;
using Models.Módulo_Carrito;
using Presentacion.Repository;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICarritoRepository _carritoRepository;

        public CarritoController(IMapper mapper, ICarritoRepository carritoRepository)
        {

            _mapper = mapper;
            _carritoRepository = carritoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                var listCarrito = await _carritoRepository.GetListCarrito();

                var listCarritosDto = _mapper.Map<IEnumerable<CarritoDTO>>(listCarrito);

                return Ok(listCarritosDto);
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
                var carrito = await _carritoRepository.GetCarrito(id);
                if (carrito == null)
                {
                    return NotFound();
                }

                var carritoDTO = _mapper.Map<CarritoDTO>(carrito);

                return Ok(carritoDTO);
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
                var carrito = await _carritoRepository.GetCarrito(id);
                if (carrito == null)
                {
                    return NotFound();
                }

                await _carritoRepository.DeleteCarrito(carrito);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(CarritoDTO carritoDto)
        {
            try
            {

                var carrito = _mapper.Map<Carrito>(carritoDto);

                carrito.fechaCreacion = DateTime.Now;

                carrito = await _carritoRepository.AddCarrito(carrito);

                var carritoItemDto = _mapper.Map<CarritoDTO>(carrito);

                return CreatedAtAction("Get", new { id = carritoItemDto.Id }, carritoItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CarritoDTO carritoDto)
        {
            try
            {
                var carritoItem = await _carritoRepository.GetCarrito(id);

                if (carritoItem == null)
                {
                    return NotFound();
                }
                
                carritoItem.name = carritoDto.name;
                carritoItem.cantidad = carritoDto.cantidad;
                carritoItem.precio = carritoDto.precio;
                carritoItem.total = carritoDto.total;

                carritoItem.fechaCreacion = DateTime.Now;

                await _carritoRepository.UpdateCarrito(carritoItem);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
