namespace Inventario.Core.Entities
{
    public class PermisosPerfil : BaseEntity
    {
        public int Id { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdMenu { get; set; }
        public virtual Menu IdMenuNavigation { get; set; } = null!;
    }
}
