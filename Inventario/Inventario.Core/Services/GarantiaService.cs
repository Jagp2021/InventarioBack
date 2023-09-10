using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class GarantiaService : BaseService, IGarantiaService
    {
        public GarantiaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
