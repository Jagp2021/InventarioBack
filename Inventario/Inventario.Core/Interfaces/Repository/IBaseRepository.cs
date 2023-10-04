using Inventario.Core.Entities;
using System.Linq.Expressions;

namespace Inventario.Core.Interfaces.Repository
{
    /// <summary>
    /// Fecha: 28 de Febrero de 2023
    /// Descripción: Interfaz que define la estructura del repositorio genérico
    /// Autor: Javier Gonzalez
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la acción de guardado sobre una entidad
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Add(TEntity entity);
        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la acción de actualización sobre una entidad
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity);
        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la acción de borrado sobre una entidad
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(TEntity entity);
        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la acción de consulta de una entidad
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la acción de consulta de un listado de entidades
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        List<TEntity> List(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Fecha: 27/07/2023
        /// Descripción: Método para cargar entidades relacionadas segun el nombre de la propiedad
        /// Autor: Manuel Linares
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="propiedadRelacionada"></param>
        /// <returns></returns>
        void LoadRelatedEntity(TEntity entidad, string propiedadRelacionada);

        /// <summary>
        /// Fecha: 27/07/2023
        /// Descripción: Método para cargar entidades relacionadas segun una propiedad
        /// Autor: Manuel Linares
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="propiedadRelacionada"></param>
        /// <returns></returns>
        void LoadRelatedEntity(TEntity entidad, Expression<Func<TEntity, object>> propiedadRelacionada);

        /// <summary>
        /// Fecha: 27/07/2023
        /// Descripción: Método para cargar colecciones de entidades relacionadas segun el nombre de la propiedad
        /// Autor: Manuel Linares
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="propiedadRelacionada"></param>
        /// <returns></returns>
        void LoadRelatedCollection(TEntity entidad, string propiedadRelacionada);

        /// <summary>
        /// Fecha: 27/07/2023
        /// Descripción: Método para cargar colecciones de entidades relacionadas segun una propiedad
        /// Autor: Manuel Linares
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="propiedadRelacionada"></param>
        /// <returns></returns>
        void LoadRelatedCollection(TEntity entidad, Expression<Func<TEntity, object>> propiedadRelacionada);
        List<TEntity> AddRange(List<TEntity> entities);
        List<TEntity> UpdateRange(List<TEntity> entities);
        List<TEntity> DeleteRange(List<TEntity> entities);
    }
}
