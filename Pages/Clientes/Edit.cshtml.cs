using AutoMapper;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.DTOs;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Implementacao;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Interfaces;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.DTOs;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._0__Apresentacao.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public EditModel(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public ClienteDTO Cliente { get; set; }

        [BindProperty]
        public List<string> Enderecos { get; set; } = new List<string>();

        [BindProperty]
        public List<int> LogradouroIds { get; set; } = new List<int>();


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
            if (Cliente.Logradouros != null)
            {
                Enderecos = Cliente.Logradouros.Select(l => l.Endereco).ToList();
                LogradouroIds = Cliente.Logradouros.Select(l => l.LogradouroId).ToList();
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAdicionarEnderecoAsync()
        {
            if (Enderecos == null)
            {
                Enderecos = new List<string>();
            }
            Enderecos.Add(""); // Adiciona um novo endereço vazio
            if (LogradouroIds == null)
            {
                LogradouroIds = new List<int>();
            }
            LogradouroIds.Add(0);
            ModelState.Clear();
            return Page();
        }

        public async Task<IActionResult> OnPostRemoverEnderecoAsync(int index)
        {
            if (Enderecos != null && index >= 0 && index < Enderecos.Count)
            {
                Enderecos.RemoveAt(index);
                if (LogradouroIds != null && index >= 0 && index < LogradouroIds.Count)
                {
                    LogradouroIds.RemoveAt(index);
                }
            }
            ModelState.Clear();
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {


            Cliente clienteParaAtualizar = new Cliente
            {
                ClienteId = Cliente.ClienteId, 
                Nome = Cliente.Nome,
                Email = Cliente.Email,
            };

            await _clienteService.UpdateAsync(clienteParaAtualizar);
            return RedirectToPage("./Index");
        }
    }
}