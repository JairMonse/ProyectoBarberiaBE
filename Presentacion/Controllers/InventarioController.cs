using AutoMapper;
using DTO.CitasDTO;
using DTO.InventarioDTO;
using Microsoft.AspNetCore.Mvc;
using Models.Módulo_Inventario;
using Presentacion.Repository;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInventarioRepository _inventarioRepository;

        public InventarioController(IMapper mapper, IInventarioRepository inventarioRepository)
        {

            _mapper = mapper;
            _inventarioRepository = inventarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                var listInventario = await _inventarioRepository.GetListInventario();

                var listInventarioDto = _mapper.Map<IEnumerable<InventarioDTO>>(listInventario);

                return Ok(listInventarioDto);
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
                var inventario = await _inventarioRepository.GetInventario(id);
                if (inventario == null)
                {
                    return NotFound();
                }

                var inventarioDTO = _mapper.Map<InventarioDTO>(inventario);

                return Ok(inventarioDTO);
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
                var inventario = await _inventarioRepository.GetInventario(id);
                if (inventario == null)
                {
                    return NotFound();
                }

                await _inventarioRepository.DeleteInventario(inventario);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post(InventarioDTO inventarioDto)
        {
            try
            {

                var inventario = _mapper.Map<Inventario>(inventarioDto);

                inventario.fechaCreacion = DateTime.Now;

                inventario = await _inventarioRepository.AddInventario(inventario);

                var inventarioItemDto = _mapper.Map<InventarioDTO>(inventario);

                return CreatedAtAction("Get", new { id = inventarioItemDto.Id }, inventarioItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, InventarioDTO inventarioDto)
        {
            try
            {
                var inventarioItem = await _inventarioRepository.GetInventario(id);

                if (inventarioItem == null)
                {
                    return NotFound();
                }

                inventarioItem.nombreProducto = inventarioDto.nombreProducto;
                inventarioItem.cantidadProducto = inventarioDto.cantidadProducto;
                inventarioItem.precio = inventarioDto.precio;
                inventarioItem.descripcion = inventarioDto.descripcion;
                inventarioItem.categoria = inventarioDto.categoria;

                await _inventarioRepository.UpdateInventario(inventarioItem);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
