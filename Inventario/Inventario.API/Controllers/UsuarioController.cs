using Inventario.Core.Dtos;
using Inventario.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("ObtenerUsuarios")]
        [SwaggerOperation(Summary = "Obtiene los usuarios", Description = "Obtiene los usuarios")]
        public ResponseDto ObtenerUsuarios([FromQuery]UsuarioDto usuario)
        {
            try
            {
                response.Data = _usuarioService.ListUsuarios(usuario);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpGet]
        [Route("ObtenerUsuario")]
        [SwaggerOperation(Summary = "Obtiene el usuario", Description = "Obtiene el usuario")]
        public ResponseDto ObtenerUsuario([FromQuery]UsuarioDto usuario)
        {
            try
            {
                response.Data = _usuarioService.GetUsuario(usuario);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("GuardarUsuario")]
        [SwaggerOperation(Summary = "Guarda el usuario", Description = "Guarda el usuario")]
        public ResponseDto GuardarUsuario([FromBody]UsuarioDto usuario)
        {
            try
            {
                response.Data = _usuarioService.SaveUsuario(usuario);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPut]
        [Route("ActualizarUsuario")]
        [SwaggerOperation(Summary = "Actualiza el usuario", Description = "Actualiza el usuario")]
        public ResponseDto ActualizarUsuario([FromBody]UsuarioDto usuario)
        {
            try
            {
                response.Data = _usuarioService.UpdateUsuario(usuario);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }
    }
}
