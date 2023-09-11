namespace Inventario.Core.Entities
{
    public class Perfil : BaseEntity
    {
        public Perfil()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
