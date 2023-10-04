namespace Inventario.Core.Dtos.Custom
{
    public class VentaDetalleDto : VentaDto
    {
        public string? NombreCliente { get; set; }
        public string? IdentificacionUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? UsernameUsuario { get; set; }
        public List<DetalleVentaDto>? DetalleFactura { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
