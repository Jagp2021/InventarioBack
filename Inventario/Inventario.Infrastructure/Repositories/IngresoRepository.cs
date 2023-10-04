using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;

namespace Inventario.Infrastructure.Repositories
{
    public class IngresoRepository : BaseRepository<Ingreso>, IIngresoRepository
    {
        private readonly EFContext _dbContext;

        public IngresoRepository(EFContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<IngresoDetalleDto> ListDetalle(IngresoDetalleDto filtro)
        {
            return (from i in _dbContext.Ingresos
                    join p in _dbContext.Proveedors on i.IdProveedor equals p.Id
                    join d in _dbContext.DetalleIngresos on i.Id equals d.IdIngreso
                    where (filtro.Id == 0 || i.Id == filtro.Id) &&
                          (filtro.IdProveedor == 0 || i.IdProveedor == filtro.IdProveedor) &&
                          (filtro.FechaInicio == null || (i.Fecha >= filtro.FechaInicio  && i.Fecha<= filtro.FechaFin)) &&
                          (filtro.IdProducto == 0 || d.IdProducto == filtro.IdProducto)
                    select new IngresoDetalleDto
                    {
                        Id = i.Id,
                        Fecha = i.Fecha,
                        IdProveedor = i.IdProveedor,
                        IdentificacionProveedor = string.Format("{0} {1}", p.TipoDocumento, p.NumeroDocumento),
                        NombreProveedor = p.Nombre,
                        DetalleIngreso = (from di in _dbContext.DetalleIngresos
                                          join pr in _dbContext.Productos on di.IdProducto equals pr.Id
                                          where di.IdIngreso == i.Id
                                          select new DetalleIngresoDto
                                          {
                                              Id = di.Id,
                                              IdIngreso = di.IdIngreso,
                                              IdProducto = di.IdProducto,
                                              Cantidad = di.Cantidad,
                                              Valor = di.Valor,
                                              NombreProducto = pr.Nombre
                                          }).ToList()
                    }).ToList();
        }
    }
}
