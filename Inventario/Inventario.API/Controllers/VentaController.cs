using Inventario.Core.Dtos.Custom;
using Inventario.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Inventario.Core.Interfaces.Service;


namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : BaseController
    {
        private readonly IVentaService _ventaService;
        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet]
        public ResponseDto ObtenerVentas([FromQuery]VentaDetalleDto filtro)
        {
            try
            {
                response.Data = _ventaService.ListVentas(filtro);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }


        [HttpPost]
        public ResponseDto GenerarVenta([FromBody] VentaDetalleDto venta)
        {
            try
            {
                response.Data = _ventaService.SaveVenta(venta);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }
    }
}
