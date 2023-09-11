namespace Inventario.Core.Entities
{
    public class Ingreso : BaseEntity
    {
        public Ingreso()
        {
            DetalleIngresos = new HashSet<DetalleIngreso>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProveedor { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual ICollection<DetalleIngreso> DetalleIngresos { get; set; }
    }
}
