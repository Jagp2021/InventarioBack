namespace Inventario.Core.Dtos
{
    public class GarantiaDto
    {
        public int Id { get; set; }
        public int? IdFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public string? EstadoGarantia { get; set; }
        public int? IdIngreso { get; set; }
        public string? TipoGarantia { get; set; }
    }
}
