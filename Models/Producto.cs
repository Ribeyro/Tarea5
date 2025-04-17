using System;
using System.Collections.Generic;

namespace Tarea5.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? CantidadInventario { get; set; }

    public int? StockMinimo { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdProveedor { get; set; }

    public virtual ICollection<Alertasstock> Alertasstocks { get; set; } = new List<Alertasstock>();

    public virtual ICollection<Detallepedidoproveedor> Detallepedidoproveedors { get; set; } = new List<Detallepedidoproveedor>();

    public virtual ICollection<Detalleventum> Detalleventa { get; set; } = new List<Detalleventum>();

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }

    public virtual ICollection<Movimientoinventario> Movimientoinventarios { get; set; } = new List<Movimientoinventario>();

    public virtual ICollection<ProveedorProducto> ProveedorProductos { get; set; } = new List<ProveedorProducto>();
}
