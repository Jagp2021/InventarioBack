namespace Inventario.Core.Entities
{
    public class Menu: BaseEntity
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Icono { get; set; }

        public string? Url { get; set; }

        public int? IdMenuPadre { get; set; }

        public virtual Menu IdMenuPadreNavigation { get; set; } = null!;

        public virtual ICollection<Menu> InverseIdMenuPadreNavigation { get; set; } = new List<Menu>();

        public virtual ICollection<PermisosPerfil> PermisosPerfils { get; set; } = new List<PermisosPerfil>();
    }
}
