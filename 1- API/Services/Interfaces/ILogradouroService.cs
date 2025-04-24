using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.DTOs;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Interfaces
{
    public interface ILogradouroService
    {
        //Task AdicionarLogradouroAsync(int clienteId, LogradouroDTO logradouroDTO);
        //Task RemoverLogradouroAsync(int logradouroId);
        //Task AtualizarLogradouroAsync(LogradouroDTO logradouroDTO);
        Task<LogradouroDTO> GetByIdAsync(int id);
        Task AddAsync(LogradouroDTO logradouroDTO);
        Task UpdateAsync(int id, LogradouroDTO logradouroDTO);
        Task DeleteAsync(int id);
    }
}
