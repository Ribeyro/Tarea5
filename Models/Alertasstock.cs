using System;
using System.Collections.Generic;

namespace Tarea5.Models;

public partial class Alertasstock
{
    public int IdAlerta { get; set; }

    public int? IdProducto { get; set; }

    public DateOnly? FechaAlerta { get; set; }

    public int? CantidadActual { get; set; }

    public int? UmbralMinimo { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
