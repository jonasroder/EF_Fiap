using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ClienteComPedidosDTO ObterPedidosSeisMeses(int id)
        {
            var cliente = _context.Cliente
                .Where(c => c.Id == id)
                .Select(c => new ClienteComPedidosDTO
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Pedidos = c.Pedidos
                        .Where(p => p.DataCriacao >= DateTime.Now.AddMonths(-6))
                        .Select(p => new PedidoDTO
                        {
                            Id = p.Id,
                            DataCriacao = p.DataCriacao,
                            Livro = new LivroDTO
                            {
                                Id = p.Livro.Id,
                                Nome = p.Livro.Nome,
                                Editora = p.Livro.Editora
                            }
                        })
                        .ToList()
                })
                .FirstOrDefault() ?? throw new Exception("Esse cliente não existe");

            return cliente;
        }
    }
}