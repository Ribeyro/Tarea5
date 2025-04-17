using System;
using System.Collections.Generic;

namespace Tarea5.Models;

public partial class Pedidoproveedor
{
    public int Id { get; set; }

    public int? ProvedorId { get; set; }

    public DateOnly? FechaPedido { get; set; }

    public DateOnly? FechaEntrega { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Detallepedidoproveedor> Detallepedidoproveedors { get; set; } = new List<Detallepedidoproveedor>();

    public virtual Proveedor? Provedor { get; set; }
}
