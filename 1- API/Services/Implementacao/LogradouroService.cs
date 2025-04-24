using AutoMapper;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.DTOs;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Repositories.Interfaces;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Interfaces;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Implementacao
{
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouroRepository _logradouroRepository;
        private readonly IMapper _mapper;

        public LogradouroService(ILogradouroRepository logradouroRepository, IMapper mapper)
        {
            _logradouroRepository = logradouroRepository;
            _mapper = mapper;
        }

        public async Task<LogradouroDTO> GetByIdAsync(int id)
        {
            var logradouro = await _logradouroRepository.GetByIdAsync(id);
            return _mapper.Map<LogradouroDTO>(logradouro);
        }

        public async Task AddAsync(LogradouroDTO logradouroDTO)
        {
            var logradouro = _mapper.Map<Logradouro>(logradouroDTO);
            await _logradouroRepository.AddAsync(logradouro);
        }

        public async Task UpdateAsync(int id, LogradouroDTO logradouroDTO)
        {
            var existingLogradouro = await _logradouroRepository.GetByIdAsync(id);
            if (existingLogradouro == null)
            {
                throw new KeyNotFoundException("Logradouro não encontrado.");
            }
            _mapper.Map(logradouroDTO, existingLogradouro);
            await _logradouroRepository.UpdateAsync(existingLogradouro);
        }

        public async Task DeleteAsync(int id)
        {
            await _logradouroRepository.DeleteAsync(id);
        }
    }
}