namespace Inventario.Core.Dtos
{
    public class PerfilDto
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; } = null!;
        public bool? Activo { get; set; }
    }
}
