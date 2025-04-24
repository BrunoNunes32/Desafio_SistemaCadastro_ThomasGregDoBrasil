using System.ComponentModel.DataAnnotations;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.DTOs
{
    public class LogradouroDTO
    {
        public int LogradouroId { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        [MaxLength(500)]
        public string Endereco { get; set; }

        public int ClienteId { get; set; }
    }
}
