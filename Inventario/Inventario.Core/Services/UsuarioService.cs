
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        public UsuarioService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
