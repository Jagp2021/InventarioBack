using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;

namespace Inventario.Core.Interfaces.Service
{
    public interface IIngresoService
    {
        List<IngresoDetalleDto> ListIngresos(IngresoDetalleDto filtro);
        IngresoDetalleDto SaveIngreso(IngresoDetalleDto ingreso);
    }
}
