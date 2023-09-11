using Inventario.Core.Dtos;
using Inventario.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("GetCliente")]
        [SwaggerOperation(Summary = "Obtener Cliente")]
        public ResponseDto GetCliente([FromQuery]ClienteDto cliente)
        {
            try
            {
                response.Data = _clienteService.GetCliente(cliente);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpGet]
        [Route("ListCliente")]
        [SwaggerOperation(Summary = "Obtener Lista Clientes")]
        public ResponseDto ListCliente([FromQuery] ClienteDto cliente)
        {
            try
            {
                response.Data = _clienteService.ListClientes(cliente);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveCliente")]
        [SwaggerOperation(Summary = "Guardar Cliente")]
        public ResponseDto SaveCliente([FromBody] ClienteDto cliente)
        {
            try
            {
                response.Data = _clienteService.SaveCliente(cliente);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPut]
        [Route("UpdateCliente")]
        [SwaggerOperation(Summary = "Actualizar Cliente")]
        public ResponseDto UpdateCliente([FromBody] ClienteDto cliente)
        {
            try
            {
                response.Data = _clienteService.UpdateCliente(cliente);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPut]
        [Route("DeleteCliente")]
        [SwaggerOperation(Summary = "Inactivar/Activar Cliente")]
        public ResponseDto DeleteCliente([FromBody] ClienteDto cliente)
        {
            try
            {
                response.Data = _clienteService.DeleteCliente(cliente);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }


    }
}
