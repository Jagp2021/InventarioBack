using Inventario.Core.Dtos;
using Inventario.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : BaseController
    {
        private readonly IPermisosService _permisosService;

        public PermisosController(IPermisosService permisosService)
        {
            _permisosService = permisosService;
        }

        [HttpGet]
        [Route("ValidarLogin")]
        [SwaggerOperation(Summary = "Validar Sesión")]
        public ResponseDto ValidarLogin(string usuario, string password)
        {
            try
            {
                response.Data = _permisosService.ValidarSesion(usuario,password);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpGet]
        [Route("CargarMenu")]
        [SwaggerOperation(Summary = "Consulta de menu por usuario")]
        public ResponseDto CargarMenu(int idUsuario)
        {
            try
            {
                response.Data = _permisosService.ListarMenu(idUsuario);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }
    }
}
