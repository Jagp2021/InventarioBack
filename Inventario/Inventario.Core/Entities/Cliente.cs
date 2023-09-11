namespace Inventario.Core.Entities
{
    public class Cliente: BaseEntity
    {
        public Cliente()
        {
            Facturas = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string TipoDocumento { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Venta> Facturas { get; set; }
    }
}
