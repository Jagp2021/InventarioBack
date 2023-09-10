using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;

namespace Inventario.Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(EFContext dbContext) : base(dbContext)
        {
        }
    }
}
