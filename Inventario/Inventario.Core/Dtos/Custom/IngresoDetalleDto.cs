namespace Inventario.Core.Dtos.Custom
{
    public class IngresoDetalleDto : IngresoDto
    {
        public string? NombreProveedor { get; set; }
        public List<DetalleIngresoDto>? DetalleIngreso { get; set; }
        public string? IdentificacionProveedor { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdProducto { get; set; }
    }
}
