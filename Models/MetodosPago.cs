using System;
using System.Collections.Generic;

namespace ProyectoIndividualMVC.Models;

public partial class MetodosPago
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string Titular { get; set; } = null!;

    public string UltimosCuatroDigitos { get; set; } = null!;

    public string Proveedor { get; set; } = null!;

    public string TokenPasarela { get; set; } = null!;

    public string FechaExpiracion { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();

    public virtual Usuario Usuario { get; set; } = null!;
}
