using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;
using System.Runtime.InteropServices;

namespace Inventario.Core.Services
{
    public class VentaService : BaseService, IVentaService
    {
        public VentaService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public List<VentaDetalleDto> ListVentas(VentaDetalleDto filtro)
        {
            var repository = UnitOfWork.VentaRepository();
            return repository.ListDetalle(filtro);
        }

        public VentaDto SaveVenta(VentaDetalleDto venta)
        {
            var repository = UnitOfWork.VentaRepository();
            var productoRepository = UnitOfWork.ProductoRepository();
            var productos = productoRepository.ListProductosAsociados(Mapper.Map<List<Producto>>(venta.DetalleFactura));
            if (ValidarStockProductos(productos, venta).Count > 0)
            {
                throw new ExternalException("No hay stock suficiente para realizar la venta");
            }
            productoRepository.UpdateRange(DescontarStock(productos, venta));
            var ventaBD = Mapper.Map<Venta>(venta);
            var result = repository.Add(ventaBD);
            UnitOfWork.SaveChanges();
            return Mapper.Map<VentaDto>(result);
        }


        private static List<Producto> ValidarStockProductos(List<Producto> productos, VentaDetalleDto venta)
        {
            return (from p in productos
                    join d in venta.DetalleFactura! on p.Id equals d.IdProducto
                    where p.CantidadDisponible < d.Cantidad
                    select p).ToList();
        }

        private static List<Producto> DescontarStock(List<Producto> productos, VentaDetalleDto venta)
        {
            return (from p in productos
                    join d in venta.DetalleFactura! on p.Id equals d.IdProducto
                    select new Producto
                    {
                        Id = p.Id,
                        CantidadDisponible = p.CantidadDisponible - d.Cantidad,
                        Codigo = p.Codigo,
                        Descripcion = p.Descripcion,
                        Estado = p.Estado,
                        Nombre = p.Nombre,
                        TipoProducto = p.TipoProducto
                    }).ToList();
        }
    }
}
