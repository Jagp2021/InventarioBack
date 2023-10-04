using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;

namespace Inventario.Core.Interfaces.Service
{
    public interface IGarantiaService
    {
        List<GarantiaDetalleDto> ListGarantias(GarantiaDetalleDto filtro);
        GarantiaDetalleDto SaveGarantia(GarantiaDetalleDto garantia, string accion);
    }
}
