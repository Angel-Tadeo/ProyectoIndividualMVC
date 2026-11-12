using System;
using System.Collections.Generic;

namespace ProyectoIndividualMVC.Models;

public partial class ResenasProducto
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public int UsuarioId { get; set; }

    public int? Calificacion { get; set; }

    public string? Comentario { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
