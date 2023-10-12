namespace Inventario.API.Controllers
{
    using Inventario.Core.Dtos;
    #region Librerias
    using Inventario.Core.Utils;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualBasic;
    using System.Net;
    using System.Runtime.InteropServices;
    #endregion

    /// <summary>
    /// Controller Base
    /// </summary>
    [ApiController]
    public class BaseController : ControllerBase
    {
        #region Atributos y Propiedades
        protected ResponseDto response;
        protected readonly ResponseDto responseError;
        #endregion

        #region Constructor
        public BaseController()
        {
            response = new ResponseDto()
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode()
            };
            responseError = new ResponseDto()
            {
                Estado = false,
                Codigo = HttpStatusCode.InternalServerError.GetHashCode(),
            };
        }
        #endregion

        #region Métodos y Funciones
        protected void ConstruirResponseError(Exception ex, bool incluirInnerException = false)
        {
            Serilog.Log.Error(ex, ex.Message);
            responseError.Mensaje = typeof(ExternalException) != ex.GetType() ? Core.Utils.Constants.General.MENSAJE_GENERICO : ex.Message;
            if (incluirInnerException && ex.InnerException != null)
                responseError.Data = ex.InnerException.Message;
            response = responseError;
        }
        #endregion
    }
}
