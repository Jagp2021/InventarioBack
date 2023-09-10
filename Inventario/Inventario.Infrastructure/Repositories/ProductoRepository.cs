using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;

namespace Inventario.Infrastructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(EFContext dbContext) : base(dbContext)
        {
        }
    }
}
