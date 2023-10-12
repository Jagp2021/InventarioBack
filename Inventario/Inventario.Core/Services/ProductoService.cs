using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class ProductoService : BaseService, IProductoService
    {

        public ProductoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public ProductoDto DeleteProducto(ProductoDto producto)
        {
            var repository = UnitOfWork.ProductoRepository();
            producto.Estado = !producto.Estado;
            repository.Update(Mapper.Map<Producto>(producto));
            UnitOfWork.SaveChanges();
            return producto;
        }

        public ProductoDetalleDto GetProducto(ProductoDto filtro)
        {
            var repository = UnitOfWork.ProductoRepository();
            return repository.List(filtro).FirstOrDefault()!;
        }

        public List<ProductoDetalleDto> ListProductos(ProductoDto filtro)
        {
            var repository = UnitOfWork.ProductoRepository();
            return repository.List(filtro);
        }

        public ProductoDto SaveProducto(ProductoDto producto)
        {
            var repository = UnitOfWork.ProductoRepository();
            var result = repository.Add(Mapper.Map<Producto>(producto));
            UnitOfWork.SaveChanges();
            return Mapper.Map<ProductoDto>(result);
        }

        public ProductoDto UpdateProducto(ProductoDto producto)
        {
            var repository = UnitOfWork.ProductoRepository();
            var result = repository.Update(Mapper.Map<Producto>(producto));
            UnitOfWork.SaveChanges();
            return Mapper.Map<ProductoDto>(result);
        }
    }
}
