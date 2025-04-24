using System.Threading.Tasks;
using System.Collections.Generic;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Repositories.Interfaces;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Services.Implementacao;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.DTOs;
using AutoMapper;


namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._1_API.Services.Implementacao
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper; // Injete o IMapper

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllAsync() 
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO> GetByIdAsync(int id) 
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return null;
            }
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }

        public async Task<ClienteDTO> GetByIdWithLogradourosAsync(int id) // Novo método para buscar com Logradouros
        {
            var cliente = await _clienteRepository.GetByIdWithLogradourosAsync(id); // Use o método do repositório
            if (cliente == null)
            {
                return null;
            }
            return _mapper.Map<ClienteDTO>(cliente);
        }
    }
}
