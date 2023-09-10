using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;

namespace Inventario.Infrastructure.Repositories
{
    public class IngresoRepository : BaseRepository<Ingreso>, IIngresoRepository
    {
        public IngresoRepository(EFContext dbContext) : base(dbContext)
        {
        }
    }
}
