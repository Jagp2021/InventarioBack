using Inventario.Core.Dtos;

namespace Inventario.Core.Interfaces.Service
{
    public interface IProductoService
    {
        List<ProductoDto> ListProductos(ProductoDto filtro);
        ProductoDto GetProducto(ProductoDto filtro);
        ProductoDto SaveProducto(ProductoDto producto);
        ProductoDto UpdateProducto(ProductoDto producto);
        ProductoDto DeleteProducto(ProductoDto producto);
    }
}
