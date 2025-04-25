using Core.Entity;

namespace Core.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPedidosSeisMeses(int id);
    }
}
