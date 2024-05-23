using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Utils;
using Inventario.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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
                    join f in _dbContext.Facturas on g.IdFactura equals f.Id into facturaGroup
                    from factura in facturaGroup.DefaultIfEmpty()
                    join c in _dbContext.Clientes on factura.Cliente equals c.Id into clienteGroup
                    from cliente in clienteGroup.DefaultIfEmpty()
                    join i in _dbContext.Ingresos on g.IdIngreso equals i.Id into ingresoGroup
                    from ingreso in ingresoGroup.DefaultIfEmpty()
                    join p in _dbContext.Proveedors on ingreso.IdProveedor equals p.Id into proveedorGroup
                    from proveedor in proveedorGroup.DefaultIfEmpty()
                    where (filtro.Id == 0 || g.Id == filtro.Id) &&
                    (string.IsNullOrEmpty(filtro.EstadoGarantia) || g.EstadoGarantia == filtro.EstadoGarantia) &&
                    (filtro.FechaInicio == null || (g.Fecha >= filtro.FechaInicio && g.Fecha <= filtro.FechaFin)) &&
                    (filtro.IdFactura == null || g.IdFactura == filtro.IdFactura) &&
                    (filtro.IdCliente == null || factura.Cliente == filtro.IdCliente) &&
                    (filtro.FechaInicioFactura == null || (factura.Fecha >= filtro.FechaInicioFactura && factura.Fecha <= filtro.FechaFinFactura))
                    select new GarantiaDetalleDto
                    {
                        EstadoGarantia = g.EstadoGarantia,
                        Fecha = g.Fecha,
                        Id = g.Id,
                        IdCliente = factura.Cliente,
                        IdProveedor = ingreso.IdProveedor,
                        IdFactura = g.IdFactura?? 0,
                        IdIngreso = g.IdIngreso?? 0,
                        DescripcionEstado = _dbContext.Dominios.FirstOrDefault(x =>
                                             x.Dominio1 == Constants.Dominio.DOMINIO_ESTADO_GARANTIA
                                                            && x.Sigla == g.EstadoGarantia)!.Descripcion,
                        IdentificacionCliente = string.Format("{0} {1}", cliente.TipoDocumento, cliente.NumeroDocumento),
                        NombreCliente = cliente.Nombre,
                        IdentificacionProveedor = string.Format("{0} {1}", proveedor.TipoDocumento, proveedor.NumeroDocumento),
                        NombreProveedor = proveedor.Nombre,
                        TipoGarantia = g.TipoGarantia,
                        DescripcionTipoGarantia = _dbContext.Dominios.FirstOrDefault(x =>
                                             x.Dominio1 == Constants.Dominio.DOMINIO_TIPO_GARANTIA
                                                            && x.Sigla == g.TipoGarantia)!.Descripcion,
                        DetalleGarantia = (from dg in _dbContext.DetalleGarantia
                                           where dg.IdGarantia == g.Id
                                           select new DetalleGarantiaDto
                                           {
                                               Cantidad = dg.Cantidad,
                                               Id = dg.Id,
                                               IdGarantia = dg.IdGarantia,
                                               IdProducto = dg.IdProducto,
                                               ValorProducto = dg.ValorProducto,
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
