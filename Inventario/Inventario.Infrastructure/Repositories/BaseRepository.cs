using Microsoft.EntityFrameworkCore;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;
using System.Linq.Expressions;
using System.Reflection;
using Inventario.Core.Entities;

namespace Inventario.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;        

        public BaseRepository(EFContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la acción de guardado sobre una entidad
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la acción de borrado sobre una entidad
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la acción de consulta de una entidad
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression)!;
        }

        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la acción de consulta de un listado de entidades
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<TEntity> List(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la acción de actualización sobre una entidad
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        /// <summary>
        /// Fecha: 27/07/2023
        /// Descripción: Método para cargar entidades relacionadas segun el nombre de la propiedad
        /// Autor: Manuel Linares
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="propiedadRelacionada"></param>
        /// <returns></returns>
        public void LoadRelatedEntity(TEntity entidad, string propiedadRelacionada)
        {
            PropertyInfo propiedad = entidad.GetType().GetProperty(propiedadRelacionada)!;
            var entry = _dbSet.Attach(entidad);
            entry.Reference(propiedad.Name).Load();
        }

        /// <summary>
        /// Fecha: 27/07/2023
        /// Descripción: Método para cargar entidades relacionadas segun una propiedad
        /// Autor: Manuel Linares
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="propiedadRelacionada"></param>
        /// <returns></returns>
        public void LoadRelatedEntity(TEntity entidad, Expression<Func<TEntity, object>> propiedadRelacionada)
        {
            string propiedadEntidad = string.Empty;
            if (propiedadRelacionada.Body is MemberExpression memberExpression)
                propiedadEntidad = memberExpression.Member.Name;
            else if (propiedadRelacionada.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand)
                propiedadEntidad = operand.Member.Name;

            var entry = _dbSet.Attach(entidad);
            entry.Reference(propiedadEntidad).Load();
        }

        /// <summary>
        /// Fecha: 27/07/2023
        /// Descripción: Método para cargar colecciones de entidades relacionadas segun el nombre de la propiedad
        /// Autor: Manuel Linares
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="propiedadRelacionada"></param>
        /// <returns></returns>
        public void LoadRelatedCollection(TEntity entidad, string propiedadRelacionada)
        {            
            PropertyInfo propiedad = entidad.GetType().GetProperty(propiedadRelacionada)!;
            var entry = _dbSet.Attach(entidad);
            entry.Collection(propiedad.Name).Load();
        }

        /// <summary>
        /// Fecha: 27/07/2023
        /// Descripción: Método para cargar colecciones de entidades relacionadas segun una propiedad
        /// Autor: Manuel Linares
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="propiedadRelacionada"></param>
        /// <returns></returns>
        public void LoadRelatedCollection(TEntity entidad, Expression<Func<TEntity, object>> propiedadRelacionada)
        {
            string propiedadColeccion = string.Empty;
            if (propiedadRelacionada.Body is MemberExpression memberExpression)
                propiedadColeccion = memberExpression.Member.Name;            
            else if (propiedadRelacionada.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand)
                propiedadColeccion = operand.Member.Name;

            var entry = _dbSet.Attach(entidad);
            entry.Collection(propiedadColeccion).Load();
        }

        public List<TEntity> UpdateRange(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            return entities;
        }

        public List<TEntity> AddRange(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            return entities;
        }

        public List<TEntity> DeleteRange(List<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            return entities;
        }
    }
}
