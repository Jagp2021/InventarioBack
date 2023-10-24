namespace Inventario.Core.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string? Username { get; set; } = null!;
        public string? Nombre { get; set; } = null!;
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public int IdPerfil { get; set; }
        public string? Password { get; set; } 
    }
}
