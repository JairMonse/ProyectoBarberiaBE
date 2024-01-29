using AutoMapper;
using DTO.BarberoDTO;
using DTO.ClienteDTO;
using Models;
using Models.Módulo_Cliente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentacion.Infrastructure;
using Shared;
using System.Transactions;
using Presentacion.Repository;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;

        private readonly IClientesRepository _clientesRepository;

        public ClientesController(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> GetClientes()
        {
            try
            {
                var clientes = await _context.Clientes.Where(x => x.Estado).ToListAsync();

                var listClientesDto = _mapper.Map<List<ClienteDTO>>(clientes);

                return Ok(listClientesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Respuesta>> PostCliente([FromBody] ClienteDTO nuevo)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var cedulaExiste = _context.Clientes.Where(x => x.Cedula == nuevo.Cedula).FirstOrDefault();
                    if (cedulaExiste != null)
                    {
                        return BadRequest(new Respuesta(false, "Cédula ya registrada"));
                    }

                    if (!string.IsNullOrEmpty(nuevo.Cedula) && !nuevo.Cedula.All(char.IsDigit))
                    {
                        return BadRequest(new Respuesta(false, "La cédula solo puede contener números."));
                    }

                    if (nuevo.Cedula.Length != 10)
                    {
                        return BadRequest(new Respuesta(false, "La cédula debe tener exactamente 10 números."));
                    }

                    if (!IsValidString(nuevo.Nombre))
                    {
                        return BadRequest(new Respuesta(false, "El nombre solo puede contener letras y espacios."));
                    }

                    if (!IsValidString(nuevo.Apellido))
                    {
                        return BadRequest(new Respuesta(false, "El apellido solo puede contener letras y espacios."));
                    }

                    var clienteNew = _mapper.Map<Cliente>(nuevo);
                    _context.Clientes.Add(clienteNew);
                    await _context.SaveChangesAsync();

                    scope.Complete();

                    return Ok(new Respuesta(true, "Cliente ingresado con éxito."));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest(new Respuesta(false, "Ha ocurrido un error"));
                }
            }
        }


        [HttpPut]
        public async Task<ActionResult<Respuesta>> PutCliente([FromBody] ClienteDTO clienteActualizado)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var clienteExistente = await _context.Clientes.Where(x => 
                    x.Id == clienteActualizado.Id && 
                    x.Estado == true)
                    .FirstOrDefaultAsync();

                    if (clienteExistente == null)
                    {
                        return NotFound(new Respuesta(false, "Cliente no encontrado."));
                    }

                    if (!string.IsNullOrEmpty(clienteActualizado.Cedula) && !clienteActualizado.Cedula.All(char.IsDigit))
                    {
                        return BadRequest(new Respuesta(false, "La cédula solo puede contener números."));
                    }

                    var cedulaExistente = await _context.Clientes
                        .Where(x => 
                            x.Cedula == clienteActualizado.Cedula && 
                            x.Id != clienteActualizado.Id)
                        .FirstOrDefaultAsync();

                    if (cedulaExistente != null)
                    {
                        return BadRequest(new Respuesta(false, "La cédula ya está registrada para otro cliente."));
                    }


                    if (clienteActualizado.Cedula.Length != 10)
                    {
                        return BadRequest(new Respuesta(false, "La cédula debe tener exactamente 10 números."));
                    }

                    if (!IsValidString(clienteActualizado.Nombre))
                    {
                        return BadRequest(new Respuesta(false, "El nombre solo puede contener letras y espacios."));
                    }

                    if (!IsValidString(clienteActualizado.Apellido))
                    {
                        return BadRequest(new Respuesta(false, "El apellido solo puede contener letras y espacios."));
                    }


                    _mapper.Map(clienteActualizado, clienteExistente);

                    await _context.SaveChangesAsync();

                    scope.Complete();

                    return Ok(new Respuesta(true, "Cliente actualizado con éxito."));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest(new Respuesta(false, "Ha ocurrido un error al actualizar el cliente."));
                }
            }
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var clientesRepository = new ClientesRepository(_context);
                var clienteExistente = await clientesRepository.GetClientes(id);

                if (clienteExistente == null)
                {
                    return NotFound($"Cliente con ID {id} no encontrado.");
                }

                await clientesRepository.DeleteCliente(clienteExistente);

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al eliminar el cliente con ID {id}: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        private bool IsValidString(string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

    }
}
