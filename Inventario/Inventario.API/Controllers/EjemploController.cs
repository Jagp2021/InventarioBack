namespace Inventario.API.Controllers
{
    #region Librerias
    using Inventario.Core.Interfaces.Service;
    using Inventario.Core.Dtos;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    #endregion

    /// <summary>
    /// Fecha: 01/09/2023
    /// Descripción: Controller Ejemplo
    /// Autor: Asesoftware - Javier Gonzalez
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EjemploController : BaseController
    {
        #region Atributos y Propiedades
        private readonly IEjemploService _ejemploService;
        #endregion

        #region Constructor
        public EjemploController(IEjemploService ejemploService)
        {
            _ejemploService = ejemploService;
        }
        #endregion

        #region Métodos y Funciones
        /// <summary>
        /// Fecha: 01/09/2023
        /// Descripción: Descripción Endpoint Ejemplo
        /// Autor: Asesoftware - Javier Gonzalez
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("NombreOperacion")]
        [SwaggerOperation(Summary = "Descricpión Endpoint")]
        public ResponseDto EndpointEjemplo(bool estado)
        {
            try
            {
                response.Data = _ejemploService.MetodoEjemplo(estado);
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }
            return response;
        }
        #endregion
    }
}
