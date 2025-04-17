using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Tarea5.Models;

namespace Tarea5.Data;

public partial class TiendaActividadContext : DbContext
{
    public TiendaActividadContext()
    {
    }

    public TiendaActividadContext(DbContextOptions<TiendaActividadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alertasstock> Alertasstocks { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Detallepedidoproveedor> Detallepedidoproveedors { get; set; }

    public virtual DbSet<Detalleventum> Detalleventa { get; set; }

    public virtual DbSet<Movimientoinventario> Movimientoinventarios { get; set; }

    public virtual DbSet<Pedidoproveedor> Pedidoproveedors { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<ProveedorProducto> ProveedorProductos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alertasstock>(entity =>
        {
            entity.HasKey(e => e.IdAlerta).HasName("PRIMARY");

            entity.ToTable("alertasstock");

            entity.HasIndex(e => e.IdProducto, "idProducto");

            entity.Property(e => e.IdAlerta)
                .ValueGeneratedNever()
                .HasColumnName("idAlerta");
            entity.Property(e => e.CantidadActual).HasColumnName("cantidadActual");
            entity.Property(e => e.FechaAlerta).HasColumnName("fechaAlerta");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.UmbralMinimo).HasColumnName("umbralMinimo");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Alertasstocks)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("alertasstock_ibfk_1");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoria");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Detallepedidoproveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detallepedidoproveedor");

            entity.HasIndex(e => e.IdPedidoProveedor, "idPedidoProveedor");

            entity.HasIndex(e => e.IdProducto, "idProducto");

            entity.HasIndex(e => e.IdProveedor, "idProveedor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CantidadSolicitada).HasColumnName("cantidadSolicitada");
            entity.Property(e => e.IdPedidoProveedor).HasColumnName("idPedidoProveedor");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precioUnitario");
            entity.Property(e => e.Subtotal)
                .HasPrecision(10, 2)
                .HasColumnName("subtotal");

            entity.HasOne(d => d.IdPedidoProveedorNavigation).WithMany(p => p.Detallepedidoproveedors)
                .HasForeignKey(d => d.IdPedidoProveedor)
                .HasConstraintName("detallepedidoproveedor_ibfk_2");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Detallepedidoproveedors)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("detallepedidoproveedor_ibfk_3");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Detallepedidoproveedors)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("detallepedidoproveedor_ibfk_1");
        });

        modelBuilder.Entity<Detalleventum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detalleventa");

            entity.HasIndex(e => e.IdProducto, "idProducto");

            entity.HasIndex(e => e.IdVenta, "idVenta");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precioUnitario");
            entity.Property(e => e.Subtotal)
                .HasPrecision(10, 2)
                .HasColumnName("subtotal");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("detalleventa_ibfk_2");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("detalleventa_ibfk_1");
        });

        modelBuilder.Entity<Movimientoinventario>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("PRIMARY");

            entity.ToTable("movimientoinventario");

            entity.HasIndex(e => e.IdProducto, "idProducto");

            entity.Property(e => e.IdMovimiento)
                .ValueGeneratedNever()
                .HasColumnName("idMovimiento");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FechaMovimiento).HasColumnName("fechaMovimiento");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Observacion)
                .HasMaxLength(200)
                .HasColumnName("observacion");
            entity.Property(e => e.TipoMovimiento)
                .HasColumnType("enum('Entrada','Salida')")
                .HasColumnName("tipoMovimiento");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Movimientoinventarios)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("movimientoinventario_ibfk_1");
        });

        modelBuilder.Entity<Pedidoproveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pedidoproveedor");

            entity.HasIndex(e => e.ProvedorId, "provedorID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.FechaEntrega).HasColumnName("fechaEntrega");
            entity.Property(e => e.FechaPedido).HasColumnName("fechaPedido");
            entity.Property(e => e.ProvedorId).HasColumnName("provedorID");

            entity.HasOne(d => d.Provedor).WithMany(p => p.Pedidoproveedors)
                .HasForeignKey(d => d.ProvedorId)
                .HasConstraintName("pedidoproveedor_ibfk_1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.IdCategoria, "id_categoria");

            entity.HasIndex(e => e.IdProveedor, "id_proveedor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CantidadInventario).HasColumnName("cantidad_inventario");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.StockMinimo).HasColumnName("stock_minimo");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("productos_ibfk_1");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("productos_ibfk_2");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<ProveedorProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedor_productos");

            entity.HasIndex(e => e.IdProducto, "idProducto");

            entity.HasIndex(e => e.IdProveedor, "idProveedor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProveedorProductos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("proveedor_productos_ibfk_2");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.ProveedorProductos)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("proveedor_productos_ibfk_1");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.IdRol, "id_rol");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("usuario_ibfk_1");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("venta");

            entity.HasIndex(e => e.IdUsuario, "idUsuario");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FechaVenta).HasColumnName("fechaVenta");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(50)
                .HasColumnName("metodoPago");
            entity.Property(e => e.TotalVenta)
                .HasPrecision(10, 2)
                .HasColumnName("totalVenta");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("venta_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
