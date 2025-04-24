using System.ComponentModel.DataAnnotations;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models
{
    public class Logradouro
    {
        public int LogradouroId { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        [MaxLength(500)]
        public string Endereco { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
