using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;

namespace Inventario.Core.Interfaces.Service
{
    public interface IVentaService
    {
        List<VentaDetalleDto> ListVentas(VentaDetalleDto filtro);
        VentaDto SaveVenta(VentaDetalleDto venta);
        string GenerarConsecutivo();
    }
}
