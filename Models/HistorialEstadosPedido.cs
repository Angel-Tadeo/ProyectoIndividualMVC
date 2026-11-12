using System;
using System.Collections.Generic;

namespace ProyectoIndividualMVC.Models;

public partial class HistorialEstadosPedido
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime? FechaActualizacion { get; set; }

    public string? Comentarios { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;
}
