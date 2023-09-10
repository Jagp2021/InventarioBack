namespace Inventario.Infrastructure.Repositories
{
    #region Atributos y Propiedades
    using Inventario.Core.Entities;
    using Inventario.Core.Interfaces.Repository;
    using Inventario.Infrastructure.Context;
    #endregion

    /// <summary>
    /// Fecha: 01 de Septiembre de 2023
    /// Descripción: Clase que define la estructura para el repositorio Ejemplo
    /// Autor: Asesoftware - Javier Gonzalez
    /// </summary>
    public class EjemploRepository : BaseRepository<Producto>, IEjemploRepository
    {
        public EjemploRepository(EFContext dbContext) : base(dbContext)
        {
        }
    }
}
