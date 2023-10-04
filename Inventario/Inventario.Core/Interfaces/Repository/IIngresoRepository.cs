using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;

namespace Inventario.Core.Interfaces.Repository
{
    public interface IIngresoRepository : IBaseRepository<Ingreso>
    {
        List<IngresoDetalleDto> ListDetalle(IngresoDetalleDto filtro);
    }
}
