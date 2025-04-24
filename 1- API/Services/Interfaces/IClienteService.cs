using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.DTOs;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Implementacao
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
        Task<ClienteDTO> GetByIdAsync(int id);
        Task<ClienteDTO> GetByIdWithLogradourosAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}