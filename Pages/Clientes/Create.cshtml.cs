using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Implementacao;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._0__Apresentacao.Pages.Clientes
{
    public class CreateModel : PageModel
    {
       private readonly IClienteService _clienteService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public Cliente Cliente { get; set; }

        [BindProperty]
        public IFormFile Logotipofile { get; set; }

        [BindProperty]
        public string[] Enderecos { get; set; }

        public CreateModel(IClienteService clienteService, IWebHostEnvironment webHostEnvironment) 
        {
            _clienteService = clienteService;
            _webHostEnvironment = webHostEnvironment; 
        }

        public IActionResult OnGet()
        {
            Cliente = new Cliente
            {
                Logradouros = new List<Logradouro>() 
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index", new { id = Cliente.ClienteId, handler = "AdicionarEndereco" });
        }
        

        private async Task<string> SaveLogoAsync(IFormFile logoFile)
        {
            if (logoFile == null || logoFile.Length == 0)
            {
                return null;
            }

            var nomeArquivo = Guid.NewGuid().ToString() + "_" + logoFile.FileName;
            var caminhoPasta = Path.Combine(_webHostEnvironment.WebRootPath, "uploads"); 
            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
            }

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await logoFile.CopyToAsync(stream);
            }

            return nomeArquivo;
        }

        public async Task<IActionResult> OnPostRemoverEnderecoAsync(int index)
        {
            // Carrega o cliente com os endereços
            if (Cliente.Logradouros != null && Cliente.Logradouros.Count > index)
            {
                Cliente.Logradouros.RemoveAt(index);
            }
            // Redireciona para a mesma página para renderizar o formulário atualizado
            return Page();
        }

        public IActionResult OnPostAdicionarEndereco()
        {
            if (Cliente.Logradouros == null)
            {
                Cliente.Logradouros = new List<Logradouro>();
            }
            Cliente.Logradouros.Add(new Logradouro());
            return Page();
        }
    }
}
