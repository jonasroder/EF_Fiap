using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{

    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext() { }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // teste adicionando uma a uma manualmente:
            /* modelBuilder.ApplyConfiguration(new Infrastructure.Configuration.ClienteConfiguration());
             modelBuilder.ApplyConfiguration(new Infrastructure.Configuration.LivroConfiguration());
             modelBuilder.ApplyConfiguration(new Infrastructure.Configuration.PedidoConfiguration());*/
        }

    }
}