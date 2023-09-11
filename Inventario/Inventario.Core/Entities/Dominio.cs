namespace Inventario.Core.Entities
{
    public class Dominio : BaseEntity
    {
        public string Dominio1 { get; set; } = null!;
        public string Sigla { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
