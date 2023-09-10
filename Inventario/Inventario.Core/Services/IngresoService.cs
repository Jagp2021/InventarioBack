using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class IngresoService : BaseService, IIngresoService
    {
        public IngresoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
