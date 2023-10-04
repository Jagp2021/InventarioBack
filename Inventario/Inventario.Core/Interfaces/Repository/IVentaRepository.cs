using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;

namespace Inventario.Core.Interfaces.Repository
{
    public interface IVentaRepository : IBaseRepository<Venta>
    {
        List<VentaDetalleDto> ListDetalle(VentaDetalleDto filtro);
    }
}
