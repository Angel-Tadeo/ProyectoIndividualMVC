using System;
using System.Collections.Generic;

namespace ProyectoIndividualMVC.Models;

public partial class Transaccione
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public int? MetodoPagoId { get; set; }

    public string FolioTransaccion { get; set; } = null!;

    public DateTime? FechaPago { get; set; }

    public decimal MontoPagado { get; set; }

    public string? ComprobanteUrl { get; set; }

    public virtual MetodosPago? MetodoPago { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;
}
