using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;

namespace Inventario.Infrastructure.Repositories
{
    public class VentaRepository : BaseRepository<Venta>, IVentaRepository
    {
        private readonly EFContext _dbContext;

        public VentaRepository(EFContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<VentaDetalleDto> ListDetalle(VentaDetalleDto filtro)
        {
            return (from v in _dbContext.Facturas
                    join c in _dbContext.Clientes on v.Cliente equals c.Id
                    where (filtro.Id == 0 || v.Id == filtro.Id) &&
                          (filtro.Cliente == 0 || v.Cliente == filtro.Cliente) &&
                          (filtro.Fecha == null || (v.Fecha >= filtro.FechaInicio && v.Fecha <= filtro.FechaFin)) &&
                          (filtro.UsuarioRegistro == 0 || v.UsuarioRegistro == filtro.UsuarioRegistro) &&
                          (filtro.IdentificacionUsuario == null || c.NumeroDocumento == filtro.IdentificacionUsuario)
                    select new VentaDetalleDto
                    {
                        Id = v.Id,
                        Fecha = v.Fecha,
                        Cliente = c.Id,
                        NombreCliente = c.Nombre,
                        IdentificacionUsuario = string.Format("{0} {1}", c.TipoDocumento, c.NumeroDocumento),
                        UsuarioRegistro = v.UsuarioRegistro,
                        NombreUsuario = _dbContext.Usuarios.FirstOrDefault(e => e.Id == v.UsuarioRegistro)!.Username,
                        DetalleFactura = (from d in _dbContext.DetalleFacturas
                                          join p in _dbContext.Productos on d.IdProducto equals p.Id
                                          where d.IdFactura == v.Id
                                          select new DetalleVentaDto
                                          {
                                              Id = d.Id,
                                              Cantidad = d.Cantidad,
                                              ValorUnitario = d.ValorUnitario,
                                              IdFactura = d.IdFactura,
                                              IdProducto = d.IdProducto,
                                              ValorTotal = d.ValorTotal,
                                              NombreProducto = p.Nombre
                                          }).ToList()
                    }).ToList();
        }
    }
}
