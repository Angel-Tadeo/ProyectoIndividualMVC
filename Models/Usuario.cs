using System;
using System.Collections.Generic;

namespace ProyectoIndividualMVC.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public int RolId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Carrito? Carrito { get; set; }

    public virtual ICollection<Devolucione> Devoluciones { get; set; } = new List<Devolucione>();

    public virtual ICollection<MetodosPago> MetodosPagos { get; set; } = new List<MetodosPago>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<ResenasProducto> ResenasProductos { get; set; } = new List<ResenasProducto>();

    public virtual Role Rol { get; set; } = null!;
}
