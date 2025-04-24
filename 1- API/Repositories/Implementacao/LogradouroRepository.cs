using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Repositories.Interfaces;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Repositories.Implementacao
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly ApplicationDbContext _context;

        public LogradouroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task AdicionarAsync(Logradouro logradouro)
        //{
        //    _context.Logradouros.Add(logradouro);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task AtualizarAsync(Logradouro logradouro)
        //{
        //    _context.Logradouros.Update(logradouro);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task RemoverAsync(int id)
        //{
        //    var logradouro = await _context.Logradouros.FindAsync(id);
        //    if (logradouro != null)
        //    {
        //        _context.Logradouros.Remove(logradouro);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task<Logradouro> ObterPorIdAsync(int id)
        //{
        //    return await _context.Logradouros.FindAsync(id);
        //}
        public async Task<Logradouro> GetByIdAsync(int id)
        {
            return await _context.Logradouros.FindAsync(id);
        }

        public async Task AddAsync(Logradouro logradouro)
        {
            _context.Logradouros.Add(logradouro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Logradouro logradouro)
        {
            _context.Entry(logradouro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var logradouro = await _context.Logradouros.FindAsync(id);
            if (logradouro != null)
            {
                _context.Logradouros.Remove(logradouro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<Logradouro> logradouros)
        {
            _context.Logradouros.RemoveRange(logradouros);
            await _context.SaveChangesAsync();
        }
    }
}