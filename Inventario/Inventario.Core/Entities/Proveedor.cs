namespace Inventario.Core.Entities
{
    public class Proveedor : BaseEntity
    {
        public Proveedor()
        {
            Ingresos = new HashSet<Ingreso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string TipoDocumento { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Ingreso> Ingresos { get; set; }
    }
}
