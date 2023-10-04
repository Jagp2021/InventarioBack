using Inventario.Core.Entities;

namespace Inventario.Core.Interfaces.Repository
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        List<Producto> ListProductosAsociados(List<Producto> filtro);
    }
}
