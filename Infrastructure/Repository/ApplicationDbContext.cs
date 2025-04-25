using Core.Entity;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Livro> Livro { get; set; }
    public DbSet<Pedido> Pedido { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        /* modelBuilder.ApplyConfiguration(new Infrastructure.Configuration.ClienteConfiguration());
         modelBuilder.ApplyConfiguration(new Infrastructure.Configuration.LivroConfiguration());
         modelBuilder.ApplyConfiguration(new Infrastructure.Configuration.PedidoConfiguration());*/
    }

}