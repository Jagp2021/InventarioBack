namespace Inventario.Core.Entities
{
    public class Venta : BaseEntity
    {
        public Venta()
        {
            DetalleFactura = new HashSet<DetalleVenta>();
        }
        public int Id { get; set; }
        public string NumeroFactura { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public int Cliente { get; set; }
        public int UsuarioRegistro { get; set; }
        public string TipoPago { get; set; } = null!;
        public decimal Total { get; set; }

        public virtual Cliente ClienteNavigation { get; set; } = null!;
        public virtual ICollection<DetalleVenta>? DetalleFactura { get; set; }
    }
}
