using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.DTOs;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Repositories.Interfaces
{
    public interface ILogradouroRepository
    {
        //Task AdicionarAsync(Logradouro logradouro);
        //Task AtualizarAsync(Logradouro logradouro);
        //Task RemoverAsync(int id);
        //Task<Logradouro> ObterPorIdAsync(int id);
        Task<Logradouro> GetByIdAsync(int id);
        Task AddAsync(Logradouro logradouro);
        Task UpdateAsync(Logradouro logradouro);
        Task DeleteAsync(int id);
        Task DeleteRangeAsync(IEnumerable<Logradouro> logradouros);
    }
}
