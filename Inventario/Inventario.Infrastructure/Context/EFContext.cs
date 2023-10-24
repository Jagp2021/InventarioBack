
namespace Inventario.Infrastructure.Context
{
    #region Librerias
    using Inventario.Core.Entities;
    using Microsoft.EntityFrameworkCore;
    #endregion
    public partial class EFContext : DbContext
    {
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleVenta> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<DetalleGarantia> DetalleGarantia { get; set; } = null!;
        public virtual DbSet<DetalleIngreso> DetalleIngresos { get; set; } = null!;
        public virtual DbSet<Dominio> Dominios { get; set; } = null!;
        public virtual DbSet<Venta> Facturas { get; set; } = null!;
        public virtual DbSet<Garantia> Garantia { get; set; } = null!;
        public virtual DbSet<Ingreso> Ingresos { get; set; } = null!;
        public virtual DbSet<Perfil> Perfils { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        public EFContext(DbContextOptions options) : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_documento");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("tipo_documento");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.ToTable("detalle_factura");

                entity.HasIndex(e => e.Id, "IXFK_detalle_factura_factura");

                entity.HasIndex(e => e.Id, "IXFK_detalle_factura_factura_02");

                entity.HasIndex(e => e.IdProducto, "IXFK_detalle_factura_producto");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("valor_total");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("valor_unitario");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_factura_factura");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_factura_producto");
            });

            modelBuilder.Entity<DetalleGarantia>(entity =>
            {
                entity.ToTable("detalle_garantia");

                entity.HasIndex(e => e.IdGarantia, "IXFK_detalle_garantia_garantia");

                entity.HasIndex(e => e.IdProducto, "IXFK_detalle_garantia_producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.EstadoProductoGarantia)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("estado_producto_garantia");

                entity.Property(e => e.IdGarantia).HasColumnName("id_garantia");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");
                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
                entity.Property(e => e.ValorProducto).HasColumnName("valor_producto");

                entity.HasOne(d => d.IdGarantiaNavigation)
                    .WithMany(p => p.DetalleGarantia)
                    .HasForeignKey(d => d.IdGarantia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_garantia_garantia");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleGarantia)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_garantia_producto");
            });

            modelBuilder.Entity<DetalleIngreso>(entity =>
            {
                entity.ToTable("detalle_ingreso");

                entity.HasIndex(e => e.IdIngreso, "IXFK_detalle_ingreso_ingresos");

                entity.HasIndex(e => e.IdProducto, "IXFK_detalle_ingreso_producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdIngreso).HasColumnName("id_ingreso");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Valor)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdIngresoNavigation)
                    .WithMany(p => p.DetalleIngresos)
                    .HasForeignKey(d => d.IdIngreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_ingreso_ingresos");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleIngresos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_ingreso_producto");
            });

            modelBuilder.Entity<Dominio>(entity =>
            {
                entity.HasKey(e => new { e.Dominio1, e.Sigla });

                entity.ToTable("dominio");

                entity.HasIndex(e => e.Dominio1, "IDX_dominio");

                entity.Property(e => e.Dominio1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dominio");

                entity.Property(e => e.Sigla)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("sigla");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("factura");

                entity.HasIndex(e => new { e.Cliente, e.Fecha, e.NumeroFactura }, "IDX_cliente");

                entity.HasIndex(e => new { e.NumeroFactura, e.Fecha }, "IDX_numero_factura");

                entity.HasIndex(e => new { e.TipoPago, e.Fecha }, "IDX_tipo_pago");

                entity.HasIndex(e => e.Cliente, "IXFK_factura_cliente");

                entity.HasIndex(e => e.Id, "IXFK_factura_detalle_factura");

                entity.HasIndex(e => e.Cliente, "IXFK_factura_usuario");

                entity.HasIndex(e => e.UsuarioRegistro, "IXFK_factura_usuario_02");

                entity.HasIndex(e => e.UsuarioRegistro, "IXFK_factura_usuario_03");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cliente).HasColumnName("cliente");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.NumeroFactura)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_factura");

                entity.Property(e => e.TipoPago)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("tipo_pago");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("total");

                entity.Property(e => e.UsuarioRegistro).HasColumnName("usuario_registro");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_factura_cliente");
            });

            modelBuilder.Entity<Garantia>(entity =>
            {
                entity.ToTable("garantia");

                entity.HasIndex(e => e.IdFactura, "IDX_factura");

                entity.HasIndex(e => e.Id, "IXFK_garantia_factura");

                entity.HasIndex(e => e.IdFactura, "IXFK_garantia_factura_02");

                entity.HasIndex(e => e.IdFactura, "IXFK_garantia_factura_03");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EstadoGarantia)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("estado_garantia");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");
            });

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.ToTable("ingresos");

                entity.HasIndex(e => e.IdProveedor, "IXFK_ingresos_proveedor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ingresos_proveedor");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("perfil");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CantidadDisponible).HasColumnName("cantidad_disponible");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.TipoProducto)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("tipo_producto");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("proveedor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_documento");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("tipo_documento");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasIndex(e => e.Username, "IDX_username");

                entity.HasIndex(e => e.IdPerfil, "IXFK_usuario_perfil");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_documento");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("tipo_documento");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasColumnName("password");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuario_perfil");
            });
        }
    }
}