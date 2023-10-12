using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using System.Dynamic;

namespace Inventario.Core.Interfaces.Repository
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        List<Producto> ListProductosAsociados(List<Producto> filtro);
        List<ProductoDetalleDto> List(ProductoDto filtro);
    }
}
