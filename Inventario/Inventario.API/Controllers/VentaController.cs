using Inventario.Core.Dtos.Custom;
using Inventario.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Inventario.Core.Interfaces.Service;
using Swashbuckle.AspNetCore.Annotations;

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

        [Route("GenerarConsecutivo")]
        [SwaggerOperation(Summary = "Generar consecutivo de venta", Description = "Generar consecutivo de venta")]
        [HttpGet]
        public ResponseDto GenerarConsecutivo()
        {
            try
            {
                response.Data = _ventaService.GenerarConsecutivo();
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }
    }
}
