namespace Inventario.Core.Dtos
{
    public class VentaDto
    {
        public int Id { get; set; }
        public string? NumeroFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public int Cliente { get; set; }
        public int UsuarioRegistro { get; set; }
        public string? TipoPago { get; set; }
        public decimal Total { get; set; }
    }
}
