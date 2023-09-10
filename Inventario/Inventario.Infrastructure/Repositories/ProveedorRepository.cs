using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;

namespace Inventario.Infrastructure.Repositories
{
    public class ProveedorRepository : BaseRepository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(EFContext dbContext) : base(dbContext)
        {
        }
    }
}
