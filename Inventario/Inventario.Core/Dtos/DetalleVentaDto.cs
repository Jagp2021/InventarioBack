namespace Inventario.Core.Dtos
{
    public class DetalleVentaDto
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public string? NombreProducto { get; set; }
    }
}
