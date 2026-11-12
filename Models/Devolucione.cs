using System;
using System.Collections.Generic;

namespace ProyectoIndividualMVC.Models;

public partial class Devolucione
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public int UsuarioId { get; set; }

    public string Motivo { get; set; } = null!;

    public string? EstadoDevolucion { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public DateTime? FechaResolucion { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
