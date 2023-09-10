namespace Inventario.Core.Services
{
    #region Librerias
    using Inventario.Core.Interfaces.Service;
    using Inventario.Core.Interfaces.Repository;
    using Inventario.Core.Services;
    using Inventario.Core.Dtos;
    #endregion

    /// <summary>
    /// Fecha: 01 de Septiembre de 2023
    /// Descripción: Clase que define los métodos del servicio Ejemplo
    /// Autor: Asesoftware - Javier Gonzalez
    /// </summary>
    public class EjemploService : BaseService, IEjemploService
    {
        #region Constructor
        public EjemploService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Métodos y Funciones
        public EjemploDto MetodoEjemplo(bool estado)
        {
            var repository = UnitOfWork.EjemploRepository();
            var result = repository.Get(e => e.Activo == estado);
            return new EjemploDto();
        }
        #endregion
    }
}
