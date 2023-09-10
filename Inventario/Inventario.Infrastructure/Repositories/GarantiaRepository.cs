using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;

namespace Inventario.Infrastructure.Repositories
{
    public class GarantiaRepository : BaseRepository<Garantia>, IGarantiaRepository
    {
        public GarantiaRepository(EFContext dbContext) : base(dbContext)
        {
        }
    }
}
