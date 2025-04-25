namespace Core.Input
{
    public class ClienteComPedidosDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<PedidoDTO> Pedidos { get; set; }
    }
}
