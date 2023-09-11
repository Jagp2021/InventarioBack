using Azure;
using Inventario.Core.Dtos;
using Inventario.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : BaseController
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        [Route("GetProveedor")]
        [SwaggerOperation(Summary = "Obtener Proveedor")]
        public ResponseDto GetProveedor([FromQuery] ProveedorDto proveedor)
        {
            try
            {
                response.Data = _proveedorService.GetProveedor(proveedor);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpGet]
        [Route("ListProveedor")]
        [SwaggerOperation(Summary = "Obtener Lista Proveedors")]
        public ResponseDto ListProveedor([FromQuery] ProveedorDto proveedor)
        {
            try
            {
                response.Data = _proveedorService.ListProveedores(proveedor);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveProveedor")]
        [SwaggerOperation(Summary = "Guardar Proveedor")]
        public ResponseDto SaveProveedor([FromBody] ProveedorDto proveedor)
        {
            try
            {
                response.Data = _proveedorService.SaveProveedor(proveedor);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPut]
        [Route("UpdateProveedor")]
        [SwaggerOperation(Summary = "Actualizar Proveedor")]
        public ResponseDto UpdateProveedor([FromBody] ProveedorDto proveedor)
        {
            try
            {
                response.Data = _proveedorService.UpdateProveedor(proveedor);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPut]
        [Route("DeleteProveedor")]
        [SwaggerOperation(Summary = "Inactivar/Activar Proveedor")]
        public ResponseDto DeleteProveedor([FromBody] ProveedorDto proveedor)
        {
            try
            {
                response.Data = _proveedorService.DeleteProveedor(proveedor);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }
    }
}
