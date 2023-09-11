namespace Inventario.Core.Dtos
{
    public class ProductoDto
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public int? CantidadDisponible { get; set; }
        public string? TipoProducto { get; set; }
    }
}
