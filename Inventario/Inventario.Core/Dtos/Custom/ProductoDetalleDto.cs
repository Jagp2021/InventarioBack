namespace Inventario.Core.Dtos.Custom
{
    public class ProductoDetalleDto : ProductoDto
    {
        public string? DescripcionTipoProducto { get; set; }
        public decimal? Precio { get; set; }
    }
}
