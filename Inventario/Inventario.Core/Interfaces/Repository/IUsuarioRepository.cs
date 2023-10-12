using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;

namespace Inventario.Core.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        List<UsuarioDetalleDto> List(UsuarioDto filtro);
    }
}
