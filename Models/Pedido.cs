using System;
using System.Collections.Generic;

namespace ProyectoIndividualMVC.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public decimal Total { get; set; }

    public string? EstadoPedido { get; set; }

    public string? MetodoPago { get; set; }

    public string DireccionEnvio { get; set; } = null!;

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<Devolucione> Devoluciones { get; set; } = new List<Devolucione>();

    public virtual ICollection<HistorialEstadosPedido> HistorialEstadosPedidos { get; set; } = new List<HistorialEstadosPedido>();

    public virtual Transaccione? Transaccione { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
