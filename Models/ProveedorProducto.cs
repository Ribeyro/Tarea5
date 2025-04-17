using System;
using System.Collections.Generic;

namespace Tarea5.Models;

public partial class ProveedorProducto
{
    public int Id { get; set; }

    public int? IdProveedor { get; set; }

    public int? IdProducto { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
