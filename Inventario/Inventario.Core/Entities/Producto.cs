
namespace Inventario.Core.Entities
{
    public class Producto : BaseEntity
    {
        public Producto()
        {
            DetalleFacturas = new HashSet<DetalleVenta>();
            DetalleGarantia = new HashSet<DetalleGarantia>();
            DetalleIngresos = new HashSet<DetalleIngreso>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
        public int CantidadDisponible { get; set; }
        public string TipoProducto { get; set; } = null!;

        public virtual ICollection<DetalleVenta> DetalleFacturas { get; set; }
        public virtual ICollection<DetalleGarantia> DetalleGarantia { get; set; }
        public virtual ICollection<DetalleIngreso> DetalleIngresos { get; set; }
    }
}
