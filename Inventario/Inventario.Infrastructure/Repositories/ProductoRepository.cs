using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
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

        public List<Producto> ListProductosAsociados(List<Producto> filtro)
        {
            return _dbContext.Productos.Where(x => filtro.Select(e => e.Id).Contains(x.Id)).AsNoTracking().ToList();
        }
    }
}
