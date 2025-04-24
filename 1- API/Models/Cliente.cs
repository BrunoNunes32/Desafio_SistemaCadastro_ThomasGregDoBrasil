using System.ComponentModel.DataAnnotations;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email em formato inválido.")]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(2048)]
        public string Logotipo { get; set; }

        public List<Logradouro> Logradouros { get; set; } = new List<Logradouro>();
    }
}
