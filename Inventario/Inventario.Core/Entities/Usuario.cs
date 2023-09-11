﻿namespace Inventario.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public int IdPerfil { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; } = null!;
    }
}
