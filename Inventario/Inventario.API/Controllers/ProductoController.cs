using Inventario.Core.Dtos;
using Inventario.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : BaseController
    {
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        [Route("GetProducto")]
        [SwaggerOperation(Summary = "Obtener Producto")]
        public ResponseDto GetProducto([FromQuery] ProductoDto producto)
        {
            try
            {
                response.Data = _productoService.GetProducto(producto);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpGet]
        [Route("ListProducto")]
        [SwaggerOperation(Summary = "Obtener Lista Productos")]
        public ResponseDto ListProducto([FromQuery] ProductoDto producto)
        {
            try
            {
                response.Data = _productoService.ListProductos(producto);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveProducto")]
        [SwaggerOperation(Summary = "Guardar Producto")]
        public ResponseDto SaveProducto([FromBody] ProductoDto producto)
        {
            try
            {
                response.Data = _productoService.SaveProducto(producto);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPut]
        [Route("UpdateProducto")]
        [SwaggerOperation(Summary = "Actualizar Producto")]
        public ResponseDto UpdateProducto([FromBody] ProductoDto producto)
        {
            try
            {
                response.Data = _productoService.UpdateProducto(producto);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }

        [HttpPut]
        [Route("DeleteProducto")]
        [SwaggerOperation(Summary = "Inactivar/Activar Producto")]
        public ResponseDto DeleteProducto([FromBody] ProductoDto producto)
        {
            try
            {
                response.Data = _productoService.DeleteProducto(producto);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }
    }
}
