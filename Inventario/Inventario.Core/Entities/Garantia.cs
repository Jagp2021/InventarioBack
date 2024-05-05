namespace Inventario.Core.Entities
{
    public class Garantia : BaseEntity
    {
        public Garantia()
        {
            DetalleGarantia = new HashSet<DetalleGarantia>();
        }

        public int Id { get; set; }
        public int? IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoGarantia { get; set; } = null!;
        public int? IdIngreso { get; set; }
        public string TipoGarantia { get; set; } = null!;
        public virtual Venta IdFacturaNavigation { get; set; } = null!;
        public virtual Ingreso IdIngresoNavigation { get; set; } = null!;
        public virtual ICollection<DetalleGarantia> DetalleGarantia { get; set; }
    }
}
