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
            var ingresos = (from i in _dbContext.Ingresos
                            join p in _dbContext.Proveedors on i.IdProveedor equals p.Id
                            join d in _dbContext.DetalleIngresos on i.Id equals d.IdIngreso
                            where (filtro.Id == 0 || i.Id == filtro.Id) &&
                                  (filtro.IdProveedor == 0 || i.IdProveedor == filtro.IdProveedor) &&
                                  (filtro.FechaInicio == null || (i.Fecha >= filtro.FechaInicio && i.Fecha <= filtro.FechaFin)) &&
                                  (filtro.IdProducto == 0 || d.IdProducto == filtro.IdProducto) &&
                                  (!filtro.GarantiaAsociada) || (filtro.GarantiaAsociada && !_dbContext.Garantia.Any(e => e.IdIngreso == i.Id))
                            group new { i, p } by new { i.Id} into g
                            select new IngresoDetalleDto
                            {
                                Id = g.Key.Id,
                                Fecha = g.First()!.i.Fecha,
                                IdProveedor = g.First()!.i.IdProveedor,
                                IdentificacionProveedor = string.Format("{0} {1}", g.First()!.p.TipoDocumento, g.First()!.p.NumeroDocumento),
                                NombreProveedor = g.First()!.p.Nombre,
                            }).Distinct().ToList();

            ingresos.ForEach(e => e.DetalleIngreso = (from di in _dbContext.DetalleIngresos
                                                     join pr in _dbContext.Productos on di.IdProducto equals pr.Id
                                                     where di.IdIngreso == e.Id
                                                     select new DetalleIngresoDto
                                                     {
                                                         Id = di.Id,
                                                         IdIngreso = di.IdIngreso,
                                                         IdProducto = di.IdProducto,
                                                         Cantidad = di.Cantidad,
                                                         Valor = di.Valor,
                                                         NombreProducto = pr.Nombre
                                                     }).ToList() );

            return ingresos;   
        }
    }
}
