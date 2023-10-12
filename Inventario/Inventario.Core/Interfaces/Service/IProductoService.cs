using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;

namespace Inventario.Core.Interfaces.Service
{
    public interface IProductoService
    {
        List<ProductoDetalleDto> ListProductos(ProductoDto filtro);
        ProductoDetalleDto GetProducto(ProductoDto filtro);
        ProductoDto SaveProducto(ProductoDto producto);
        ProductoDto UpdateProducto(ProductoDto producto);
        ProductoDto DeleteProducto(ProductoDto producto);
    }
}
