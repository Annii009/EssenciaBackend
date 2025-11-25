using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Models;
public class Pedidos
{
    public int PedidoId { get; set;}
    public int MesaId { get; set; }
    public Mesas? Mesa { get; set; }
    public DateTime FechaHoraPedido { get; set; }
    public bool PedidoCompletado {get; set;} = false;
    public decimal Total {get; set;}
    public string Notas {get; set;}
    public List<DetallePedido> DetallesPedidos {get; set;} = new();
}