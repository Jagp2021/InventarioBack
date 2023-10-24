using Inventario.Core.Dtos.Custom;
using Inventario.Core.Dtos;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;
using Inventario.Core.Utils;

namespace Inventario.Infrastructure.Repositories
{
    public class ProveedorRepository : BaseRepository<Proveedor>, IProveedorRepository
    {
        #region Atributos y Propiedades
        private readonly EFContext _dbContext;
        #endregion
        public ProveedorRepository(EFContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProveedorDetalleDto> List(ProveedorDto filtro)
        {
            return (from p in _dbContext.Proveedors
                    where (filtro.Id == null || p.Id == filtro.Id) &&
                    (string.IsNullOrEmpty(filtro.Email) || p.Email == filtro.Email) &&
                    (string.IsNullOrEmpty(filtro.Nombre) || p.Nombre == filtro.Nombre) &&
                    (string.IsNullOrEmpty(filtro.Telefono) || p.Telefono == filtro.Telefono) &&
                    (string.IsNullOrEmpty(filtro.TipoDocumento) || p.TipoDocumento == filtro.TipoDocumento) &&
                    (string.IsNullOrEmpty(filtro.NumeroDocumento) || p.NumeroDocumento == filtro.NumeroDocumento)
                    select new ProveedorDetalleDto { 
                     TipoDocumento = p.TipoDocumento,
                     NumeroDocumento = p.NumeroDocumento,
                     Nombre = p.Nombre,
                     Email = p.Email,
                     Telefono = p.Telefono,
                     Id = p.Id,
                      DescripcionTipoDocumento = _dbContext.Dominios.FirstOrDefault(e => e.Dominio1 == Constants.Dominio.DOMINIO_TIPO_DOCUMENTO && e.Sigla == p.TipoDocumento)!.Descripcion

                    }).ToList();
        }
    }
}
