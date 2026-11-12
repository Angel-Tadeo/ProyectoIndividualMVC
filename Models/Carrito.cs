using System;
using System.Collections.Generic;

namespace ProyectoIndividualMVC.Models;

public partial class Carrito
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<DetalleCarrito> DetalleCarritos { get; set; } = new List<DetalleCarrito>();

    public virtual Usuario Usuario { get; set; } = null!;
}
