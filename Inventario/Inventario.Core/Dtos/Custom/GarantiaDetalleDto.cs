namespace Inventario.Core.Dtos.Custom
{
    public class GarantiaDetalleDto : GarantiaDto
    {
        public List<DetalleGarantiaDto>? DetalleGarantia { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaInicioFactura { get; set; }
        public DateTime? FechaFinFactura { get; set; }
        public string? NombreCliente { get; set; }
        public string? IdentificacionCliente { get; set; }
        public string? DescripcionEstado { get; set; }
        public string? DescripcionTipoGarantia { get; set; }
        public int? IdProveedor { get; set; }
        public string? NombreProveedor { get; set; }
        public string? IdentificacionProveedor { get; set; }
    }
}
