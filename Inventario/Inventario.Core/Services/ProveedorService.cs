using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class ProveedorService : BaseService, IProveedorService
    {
        public ProveedorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
