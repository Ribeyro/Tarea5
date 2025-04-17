using System;
using System.Collections.Generic;

namespace Tarea5.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Detallepedidoproveedor> Detallepedidoproveedors { get; set; } = new List<Detallepedidoproveedor>();

    public virtual ICollection<Pedidoproveedor> Pedidoproveedors { get; set; } = new List<Pedidoproveedor>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<ProveedorProducto> ProveedorProductos { get; set; } = new List<ProveedorProducto>();
}
