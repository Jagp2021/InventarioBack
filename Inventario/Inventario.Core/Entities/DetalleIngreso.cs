namespace Inventario.Core.Entities
{
    public class DetalleIngreso : BaseEntity
    {
        public int Id { get; set; }
        public int IdIngreso { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Valor { get; set; }

        public virtual Ingreso IdIngresoNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
