namespace Inventario.Core.Services
{
    #region Librerias
    using AutoMapper;
    using Inventario.Core.Interfaces.Repository;
    #endregion

    /// <summary>
    /// Fecha: 01 de Septiembre de 2023
    /// Descripción: Clase que define los métodos del servicio base
    /// Autor: Javier Gonzalez
    /// </summary>
    public class BaseService
    {
        #region Atributos y Propiedades
        protected internal IUnitOfWork UnitOfWork { get; set; }
        protected internal IMapper Mapper { get; set; }
        #endregion

        #region Constructor
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        #endregion

        #region Métodos y Funciones
        public IUnitOfWork GeNewtInstanceUnitOfWork()
        {
            return UnitOfWork.GetNewInstanceUnitOfWork();
        }

        public IMapper GetNewInstanceMapper()
        {
            return UnitOfWork.GetNewInstanceMapper();
        }
        #endregion
    }
}
