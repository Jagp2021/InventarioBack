using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;

namespace Inventario.Core.Interfaces.Repository
{
    public interface IGarantiaRepository : IBaseRepository<Garantia>
    {
        List<GarantiaDetalleDto> ListDetalle(GarantiaDetalleDto filtro);
    }
}
