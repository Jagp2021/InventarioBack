using AutoMapper;
using Inventario.Core.Dtos;
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

        public ProductoDto GetProducto(ProductoDto filtro)
        {
            var repository = UnitOfWork.ProductoRepository();
            return Mapper.Map<ProductoDto>(repository.Get(e => e.Id == filtro.Id));
        }

        public List<ProductoDto> ListProductos(ProductoDto filtro)
        {
            var repository = UnitOfWork.ProductoRepository();
            return Mapper.Map<List<ProductoDto>>(repository.List(e => 
            (filtro.Id == null || e.Id == filtro.Id) && 
            (string.IsNullOrEmpty(filtro.TipoProducto) || e.TipoProducto == filtro.TipoProducto) &&
            (string.IsNullOrEmpty(filtro.Nombre) || e.Nombre == filtro.Nombre) &&
            (string.IsNullOrEmpty(filtro.Descripcion) || e.Descripcion == filtro.Descripcion) &&
            (!filtro.Estado.HasValue || e.Estado == filtro.Estado)
            
            ));
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
