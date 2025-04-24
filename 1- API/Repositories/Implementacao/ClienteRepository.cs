using Microsoft.EntityFrameworkCore;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.Infra.Data;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Repositories.Interfaces;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._1_API.Data.Repositories.Implementacao
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> GetByIdWithLogradourosAsync(int id)
        {
            return await _context.Clientes
                .Include(c => c.Logradouros) 
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }


        public async Task AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
