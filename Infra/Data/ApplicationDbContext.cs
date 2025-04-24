using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }


    }
}
