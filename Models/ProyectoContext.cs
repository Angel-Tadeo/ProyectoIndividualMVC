using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIndividualMVC.Models;

public partial class ProyectoContext : DbContext
{
    public ProyectoContext(DbContextOptions<ProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<DetalleCarrito> DetalleCarritos { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Devolucione> Devoluciones { get; set; }

    public virtual DbSet<HistorialEstadosPedido> HistorialEstadosPedidos { get; set; }

    public virtual DbSet<MetodosPago> MetodosPagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ResenasProducto> ResenasProductos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carritos__3214EC076A33B17B");

            entity.HasIndex(e => e.UsuarioId, "UQ__Carritos__2B3DE7B9D7535364").IsUnique();

            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithOne(p => p.Carrito)
                .HasForeignKey<Carrito>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carritos_Usuarios");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07813A5BED");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<DetalleCarrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleC__3214EC07CCA0F4BD");

            entity.HasOne(d => d.Carrito).WithMany(p => p.DetalleCarritos)
                .HasForeignKey(d => d.CarritoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCarritos_Carritos");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleCarritos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCarritos_Productos");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleP__3214EC07CDB043BD");

            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Pedido).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePedidos_Pedidos");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePedidos_Productos");
        });

        modelBuilder.Entity<Devolucione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Devoluci__3214EC0785CF95A3");

            entity.Property(e => e.EstadoDevolucion)
                .HasMaxLength(50)
                .HasDefaultValue("Solicitada");
            entity.Property(e => e.FechaResolucion).HasColumnType("datetime");
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Devoluciones)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Devoluciones_Pedidos");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Devoluciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Devoluciones_Usuarios");
        });

        modelBuilder.Entity<HistorialEstadosPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC07F00D8CC5");

            entity.ToTable("HistorialEstadosPedido");

            entity.Property(e => e.Comentarios).HasMaxLength(255);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Pedido).WithMany(p => p.HistorialEstadosPedidos)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Pedidos");
        });

        modelBuilder.Entity<MetodosPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MetodosP__3214EC0780B69808");

            entity.ToTable("MetodosPago");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaExpiracion).HasMaxLength(5);
            entity.Property(e => e.Proveedor).HasMaxLength(50);
            entity.Property(e => e.Titular).HasMaxLength(150);
            entity.Property(e => e.TokenPasarela).HasMaxLength(255);
            entity.Property(e => e.UltimosCuatroDigitos).HasMaxLength(4);

            entity.HasOne(d => d.Usuario).WithMany(p => p.MetodosPagos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MetodosPago_Usuarios");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedidos__3214EC075B4E3BBA");

            entity.Property(e => e.DireccionEnvio).HasMaxLength(255);
            entity.Property(e => e.EstadoPedido)
                .HasMaxLength(50)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MetodoPago).HasMaxLength(50);
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedidos_Usuarios");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC079235091F");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.ImagenUrl).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Categorias");
        });

        modelBuilder.Entity<ResenasProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ResenasP__3214EC07C07F9CC8");

            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Producto).WithMany(p => p.ResenasProductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resenas_Productos");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ResenasProductos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resenas_Usuarios");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC070F3E46C4");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transacc__3214EC074AE12007");

            entity.HasIndex(e => e.PedidoId, "UQ__Transacc__09BA143146D4A059").IsUnique();

            entity.HasIndex(e => e.FolioTransaccion, "UQ__Transacc__DB12480F23B5DCB0").IsUnique();

            entity.Property(e => e.ComprobanteUrl).HasMaxLength(255);
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FolioTransaccion).HasMaxLength(100);
            entity.Property(e => e.MontoPagado).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.MetodoPagoId)
                .HasConstraintName("FK_Transacciones_MetodosPago");

            entity.HasOne(d => d.Pedido).WithOne(p => p.Transaccione)
                .HasForeignKey<Transaccione>(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transacciones_Pedidos");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC070A2AA050");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A1909A07E57").IsUnique();

            entity.Property(e => e.Apellidos).HasMaxLength(150);
            entity.Property(e => e.Correo).HasMaxLength(150);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
