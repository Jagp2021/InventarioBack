using Inventario.Core.Dtos;
using Inventario.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DominioController : BaseController
    {
        #region Atributos y Propiedades
        private readonly IDominioService _dominioService;
        #endregion
        public DominioController(IDominioService dominioService)
        {
            _dominioService = dominioService;
        }

        [HttpGet]
        [Route("ObtenerDominios")]
        [SwaggerOperation(Summary = "Obtiene los dominios", Description = "Obtiene los dominios")]
        public ResponseDto ObtenerDominios([FromQuery] DominioDto dominio)
        {
            try
            {
                response.Data = _dominioService.ListDominios(dominio);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpGet]
        [Route("ObtenerPerfiles")]
        [SwaggerOperation(Summary = "Obtiene los perfiles", Description = "Obtiene los perfiles")]
        public ResponseDto ObtenerPerfiles()
        {
            try
            {
                response.Data = _dominioService.ListPerfiles();
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }
    }
}
