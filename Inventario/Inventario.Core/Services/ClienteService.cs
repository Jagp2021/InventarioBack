using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        public ClienteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
