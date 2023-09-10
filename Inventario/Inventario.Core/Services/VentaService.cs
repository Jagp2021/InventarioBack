using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class VentaService : BaseService, IVentaService
    {
        public VentaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
