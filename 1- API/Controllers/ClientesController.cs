using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Implementacao;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            var clientes = await _clienteService.GetAllAsync(); 

            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

    }
}
