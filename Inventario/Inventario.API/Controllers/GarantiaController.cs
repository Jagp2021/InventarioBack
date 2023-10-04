using Inventario.Core.Dtos.Custom;
using Inventario.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Inventario.Core.Interfaces.Service;
using Inventario.Core.Utils;

namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarantiaController : BaseController
    {
        private readonly IGarantiaService _garantiaService;
        public GarantiaController(IGarantiaService garantiaService)
        {
            _garantiaService = garantiaService;
        }
        [HttpGet]
        public ResponseDto ObtenerIngresos([FromQuery]GarantiaDetalleDto garantia)
        {
            try
            {
                response.Data = _garantiaService.ListGarantias(garantia);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }


        [HttpPost]
        public ResponseDto CrearGarantia([FromBody] GarantiaDetalleDto garantia)
        {
            try
            {
                response.Data = _garantiaService.SaveGarantia(garantia,Constants.General.ACCION_GUARDAR);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPut]
        public ResponseDto ActualizarGarantia([FromBody] GarantiaDetalleDto garantia)
        {
            try
            {
                response.Data = _garantiaService.SaveGarantia(garantia,Constants.General.ACCION_ACTUALIZAR);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }
    }
}
