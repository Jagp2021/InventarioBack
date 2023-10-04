namespace Inventario.Core.Dtos
{
    public class DetalleIngresoDto
    {
        public int Id { get; set; }
        public int IdIngreso { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Valor { get; set; }
        public string? NombreProducto { get; set; }
    }
}
