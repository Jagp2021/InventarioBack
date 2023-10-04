using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Utils;
using Inventario.Infrastructure.Context;

namespace Inventario.Infrastructure.Repositories
{
    public class GarantiaRepository : BaseRepository<Garantia>, IGarantiaRepository
    {
        private readonly EFContext _dbContext;
        public GarantiaRepository(EFContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<GarantiaDetalleDto> ListDetalle(GarantiaDetalleDto filtro)
        {
            return (from g in _dbContext.Garantia
                    join f in _dbContext.Facturas on g.IdFactura equals f.Id
                    join c in _dbContext.Clientes on f.Cliente equals c.Id
                    where (filtro.Id == 0 || g.Id == filtro.Id) &&
                    (string.IsNullOrEmpty(filtro.EstadoGarantia) || g.EstadoGarantia == filtro.EstadoGarantia) &&
                    (filtro.FechaInicio == null || (g.Fecha >= filtro.FechaInicio && g.Fecha <= filtro.FechaFin)) &&
                    (filtro.IdFactura == 0 || g.IdFactura == filtro.IdFactura) &&
                    (filtro.IdCliente == 0 || f.Cliente == filtro.IdCliente) &&
                    (filtro.FechaInicioFactura == null || (f.Fecha >= filtro.FechaInicioFactura && f.Fecha <= filtro.FechaFinFactura))
                    select new GarantiaDetalleDto
                    {
                        EstadoGarantia = g.EstadoGarantia,
                        Fecha = g.Fecha,
                        Id = g.Id,
                        IdCliente = f.Cliente,
                        IdFactura = g.IdFactura,
                        DescripcionEstado = _dbContext.Dominios.FirstOrDefault(x =>
                                             x.Dominio1 == Constants.Dominio.DOMINIO_ESTADO_GARANTIA
                                                            && x.Sigla == g.EstadoGarantia)!.Descripcion,
                        IdentificacionCliente = string.Format("{0} {1}", c.TipoDocumento, c.NumeroDocumento),
                        NombreCliente = c.Nombre,
                        DetalleGarantia = (from dg in _dbContext.DetalleGarantia
                                           where dg.IdGarantia == g.Id
                                           select new DetalleGarantiaDto
                                           {
                                               Cantidad = dg.Cantidad,
                                               Id = dg.Id,
                                               IdGarantia = dg.IdGarantia,
                                               IdProducto = dg.IdProducto,
                                               EstadoProductoGarantia = dg.EstadoProductoGarantia,
                                               NombreProducto = _dbContext.Productos.FirstOrDefault(x => x.Id == dg.IdProducto)!.Nombre,
                                               NombreProveedor = !dg.IdProveedor.HasValue ? "" :
                                                            _dbContext.Proveedors.FirstOrDefault(x => x.Id == dg.IdProveedor)!.Nombre,
                                               DescripcionEstado = _dbContext.Dominios.FirstOrDefault(x => 
                                                            x.Dominio1 == Constants.Dominio.DOMINIO_ESTADO_GARANTIA 
                                                            && x.Sigla == dg.EstadoProductoGarantia)!.Descripcion
                                               
                                           }).ToList()
                    }
                    ).ToList();
        }
    }
}
