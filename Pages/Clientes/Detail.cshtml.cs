using AutoMapper;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Implementacao;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._0__Apresentacao.Pages.Clientes
{
    public class DetailModel : PageModel
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public DetailModel(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public ClienteDTO Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Cliente = await _clienteService.GetByIdAsync(id);
            if (Cliente == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}