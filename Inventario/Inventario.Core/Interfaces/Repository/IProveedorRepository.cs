using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;

namespace Inventario.Core.Interfaces.Repository
{
    public interface IProveedorRepository : IBaseRepository<Proveedor>
    {
        List<ProveedorDetalleDto> List(ProveedorDto filtro);
    }
}
