namespace Models;
public class DetallePedido
{
    public int DetallePedidoId {get; set;}
    public int PedidoId {get; set;}
    public Pedidos? Pedido {get; set;}
    public int? ProductoCafeteriaId {get; set;}
    public ProductosCafeteria? ProductoCafeteria {get; set;}
    public int? ProductoFloristeriaId {get; set;}
    public ProductosFloristeria? ProductoFloristeria {get; set;}
    public int Cantidad {get; set;}
    public decimal PrecioUnitario {get; set;}
}