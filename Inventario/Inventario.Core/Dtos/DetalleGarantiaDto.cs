namespace Inventario.Core.Dtos
{
    public class DetalleGarantiaDto
    {
        public int Id { get; set; }
        public int IdGarantia { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string? EstadoProductoGarantia { get; set; }
        public int? IdProveedor { get; set; }
        public decimal? ValorProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string? NombreProveedor { get; set; }
        public string? DescripcionEstado { get; set; }
    }
}
