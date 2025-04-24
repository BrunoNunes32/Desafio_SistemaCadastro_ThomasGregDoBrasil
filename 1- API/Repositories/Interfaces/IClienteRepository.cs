using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> GetByIdWithLogradourosAsync(int id); 
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}
