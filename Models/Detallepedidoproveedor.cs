using System;
using System.Collections.Generic;

namespace Tarea5.Models;

public partial class Detallepedidoproveedor
{
    public int Id { get; set; }

    public int? IdProveedor { get; set; }

    public int? IdPedidoProveedor { get; set; }

    public int? IdProducto { get; set; }

    public int? CantidadSolicitada { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Pedidoproveedor? IdPedidoProveedorNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
