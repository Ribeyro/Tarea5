using System;
using System.Collections.Generic;

namespace Tarea5.Models;

public partial class Movimientoinventario
{
    public int IdMovimiento { get; set; }

    public int? IdProducto { get; set; }

    public string? TipoMovimiento { get; set; }

    public int? Cantidad { get; set; }

    public DateOnly? FechaMovimiento { get; set; }

    public string? Observacion { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
