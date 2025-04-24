using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil.API.DTOs
{
    public class ClienteDTO
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email em formato inválido.")]
        [MaxLength(255)]
        public string Email { get; set; }

        public IFormFile LogotipoFile { get; set; }

        public string Logotipo { get; set; }

        public List<LogradouroDTO> Logradouros { get; set; } = new List<LogradouroDTO>();
    }
}
