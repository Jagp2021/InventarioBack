namespace Inventario.Core.Entities
{
    public class DetalleGarantia : BaseEntity
    {
        public int Id { get; set; }
        public int IdGarantia { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string EstadoProductoGarantia { get; set; } = null!;

        public virtual Garantia IdGarantiaNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
