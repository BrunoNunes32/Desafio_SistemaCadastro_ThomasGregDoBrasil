using AutoMapper;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Implementacao;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._0__Apresentacao.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public DeleteModel(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [BindProperty(SupportsGet = true)]
        public int Id
        {
            get; set;
        }

        [BindProperty]
        public ClienteDTO Cliente
        {
            get; set;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Cliente = await _clienteService.GetByIdWithLogradourosAsync(id);
            if (Cliente == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            await _clienteService.DeleteAsync(id);
            return RedirectToPage("./Index");
        }
    }
}