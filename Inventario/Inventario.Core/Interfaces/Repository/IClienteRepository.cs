using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;

namespace Inventario.Core.Interfaces.Repository
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        List<ClienteDetalleDto> List(ClienteDto filtro);
    }
}
