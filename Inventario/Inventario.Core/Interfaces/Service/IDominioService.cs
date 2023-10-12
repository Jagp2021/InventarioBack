using Inventario.Core.Dtos;

namespace Inventario.Core.Interfaces.Service
{
    public interface IDominioService
    {
        List<DominioDto> ListDominios(DominioDto filtro);
        List<PerfilDto> ListPerfiles();
    }
}
