using AutoMapper;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Implementacao;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._0__Apresentacao.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public IndexModel(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        public IList<ClienteDTO> Clientes { get; set; } = new List<ClienteDTO>(); // Inicializar a lista

        public async Task OnGetAsync()
        {
            var clientesDTO = await _clienteService.GetAllAsync();
            if (clientesDTO != null)
            {
                Clientes = _mapper.Map<List<ClienteDTO>>(clientesDTO);
            }
        }
    }
}
