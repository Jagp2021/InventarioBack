using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;

namespace Inventario.Infrastructure.Repositories
{
    public class VentaRepository : BaseRepository<Venta>, IVentaRepository
    {
        public VentaRepository(EFContext dbContext) : base(dbContext)
        {
        }
    }
}
