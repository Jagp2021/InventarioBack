using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresoController : BaseController
    {
        private readonly IIngresoService _ingresoService;
        public IngresoController(IIngresoService ingresoService)
        {
            _ingresoService = ingresoService;
        }

        [HttpGet]
        public ResponseDto ObtenerIngresos([FromQuery]IngresoDetalleDto ingreso)
        {
            try
            {
                response.Data = _ingresoService.ListIngresos(ingreso);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        
        [HttpPost]
        public ResponseDto CrearIngreso([FromBody] IngresoDetalleDto ingreso)
        {
            try
            {
                response.Data = _ingresoService.SaveIngreso(ingreso);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        
    }
}
