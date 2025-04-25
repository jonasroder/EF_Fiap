using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(u => u.DataCriacao).HasColumnType("DATETIME2").IsRequired();
            builder.Property(u => u.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.DataNascimento).HasColumnType("DATETIME2");

            builder.HasData(
                new Cliente { Id = 1, Nome = "Ana Silva teste2", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1990, 1, 12) },
                new Cliente { Id = 2, Nome = "Bruno Souza", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1985, 5, 23) },
                new Cliente { Id = 3, Nome = "Carla Pereira teste2", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1992, 3, 14) },
                new Cliente { Id = 4, Nome = "Diego Costa", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1988, 7, 9) },
                new Cliente { Id = 5, Nome = "Eduarda Lima", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1991, 8, 20) },
                new Cliente { Id = 6, Nome = "Fernando Rocha", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1983, 12, 4) },
                new Cliente { Id = 7, Nome = "Gabriela Mendes", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1994, 2, 18) },
                new Cliente { Id = 8, Nome = "Henrique Alves", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1989, 11, 30) },
                new Cliente { Id = 9, Nome = "Isabelly Gomes", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1995, 4, 15) },
                new Cliente { Id = 11, Nome = "Karina Teixeira", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1993, 9, 3) },
                new Cliente { Id = 12, Nome = "Lucas Vieira", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1987, 10, 11) },
                new Cliente { Id = 13, Nome = "Mariana Cruz", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1996, 1, 5) },
                new Cliente { Id = 14, Nome = "Nathan Ribeiro", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1984, 5, 19) },
                new Cliente { Id = 15, Nome = "Olivia Barros", DataCriacao = new DateTime(2024, 4, 25, 0, 0, 0), DataNascimento = new DateTime(1997, 7, 22) }
            );
        }
    }
}
