using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class ProductoService : BaseService, IProductoService
    {
        public ProductoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
