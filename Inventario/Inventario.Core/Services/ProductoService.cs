using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class ProductoService : BaseService, IProductoService
    {
        private readonly IMapper _mapper;

        public ProductoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public ProductoDto DeleteProducto(ProductoDto producto)
        {
            var repository = UnitOfWork.ProductoRepository();
            producto.Estado = !producto.Estado;
            repository.Update(_mapper.Map<Producto>(producto));
            UnitOfWork.SaveChanges();
            return producto;
        }

        public ProductoDto GetProducto(ProductoDto filtro)
        {
            var repository = UnitOfWork.ProductoRepository();
            return _mapper.Map<ProductoDto>(repository.Get(e => e.Id == filtro.Id));
        }

        public List<ProductoDto> ListProductos(ProductoDto filtro)
        {
            var repository = UnitOfWork.ProductoRepository();
            return _mapper.Map<List<ProductoDto>>(repository.List(e => e.Id == filtro.Id));
        }

        public ProductoDto SaveProducto(ProductoDto producto)
        {
            var repository = UnitOfWork.ProductoRepository();
            var result = repository.Add(_mapper.Map<Producto>(producto));
            UnitOfWork.SaveChanges();
            return _mapper.Map<ProductoDto>(result);
        }

        public ProductoDto UpdateProducto(ProductoDto producto)
        {
            var repository = UnitOfWork.ProductoRepository();
            var result = repository.Update(_mapper.Map<Producto>(producto));
            UnitOfWork.SaveChanges();
            return _mapper.Map<ProductoDto>(result);
        }
    }
}
