using System;
using System.Collections.Generic;

namespace Tarea5.Models;

public partial class Ventum
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public DateOnly? FechaVenta { get; set; }

    public decimal? TotalVenta { get; set; }

    public string? MetodoPago { get; set; }

    public virtual ICollection<Detalleventum> Detalleventa { get; set; } = new List<Detalleventum>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
