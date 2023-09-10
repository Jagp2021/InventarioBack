namespace Inventario.Core.Interfaces.Repository
{
    #region Librerias
    using AutoMapper;
    using Inventario.Core.Entities;
    #endregion
    /// <summary>
    /// Fecha: 01 de Septiembre de 2023
    /// Descripción: Interfaz que define la estructura para el repositorio General
    /// Autor: Asesoftware - Javier Gonzalez
    /// </summary>
    public interface IUnitOfWork
    {
        IUnitOfWork GetNewInstanceUnitOfWork();
        IMapper GetNewInstanceMapper();
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IBaseRepository<T> BaseRepository<T>() where T : BaseEntity;
        IEjemploRepository EjemploRepository();
        IClienteRepository ClienteRepository();
        IGarantiaRepository GarantiaRepository();
        IIngresoRepository IngresoRepository();
        IProductoRepository ProductoRepository();
        IProveedorRepository ProveedorRepository();
        IUsuarioRepository UsuarioRepository();
        IVentaRepository VentaRepository();

    }
}
