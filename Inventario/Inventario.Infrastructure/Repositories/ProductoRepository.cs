using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Utils;
using Inventario.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Infrastructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
        private readonly EFContext _dbContext;
        public ProductoRepository(EFContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductoDetalleDto> List(ProductoDto filtro)
        {
            decimal valor = 0;
            var result =  (from pr in _dbContext.Productos
                    select new ProductoDetalleDto
                    {
                        Codigo = pr.Codigo,
                        CantidadDisponible = pr.CantidadDisponible,
                        Descripcion = pr.Descripcion,
                        Estado = pr.Estado,
                        Id = pr.Id,
                        Nombre = pr.Nombre,
                        TipoProducto = pr.TipoProducto,
                        DescripcionTipoProducto = _dbContext.Dominios.FirstOrDefault(e => e.Dominio1 == Constants.Dominio.DOMINIO_TIPO_PRODUCTO)!.Descripcion,
                        Precio = _dbContext.DetalleIngresos.OrderBy(e => e.Id).LastOrDefault(e => e.IdProducto == pr.Id)!.Valor
                    }
                    ).ToList();
            return result;                                                                                                                                           
        }

        public List<Producto> ListProductosAsociados(List<Producto> filtro)
        {
            return _dbContext.Productos.Where(x => filtro.Select(e => e.Id).Contains(x.Id)).AsNoTracking().ToList();
        }
    }
}
