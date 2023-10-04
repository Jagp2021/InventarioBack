using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class IngresoService : BaseService, IIngresoService
    {
        public IngresoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public List<IngresoDetalleDto> ListIngresos(IngresoDetalleDto filtro)
        {
            var repository = UnitOfWork.IngresoRepository();
            return Mapper.Map<List<IngresoDetalleDto>>(repository.ListDetalle(filtro));
        }

        public IngresoDetalleDto SaveIngreso(IngresoDetalleDto ingreso)
        {
            var repository = UnitOfWork.IngresoRepository();
            var productoRepository = UnitOfWork.ProductoRepository();
            var productos  = productoRepository.ListProductosAsociados(Mapper.Map<List<Producto>>(ingreso.DetalleIngreso));
            productoRepository.UpdateRange(ActualizarInventario(productos, ingreso.DetalleIngreso!));
            var result = repository.Add(Mapper.Map<Ingreso>(ingreso));
            UnitOfWork.SaveChanges();
            return Mapper.Map<IngresoDetalleDto>(result);
        }

        private static List<Producto> ActualizarInventario(List<Producto> productos, List<DetalleIngresoDto> detalleIngreso)
        {
            return (from p in productos
                    join d in detalleIngreso on p.Id equals d.IdProducto
                    select new Producto
                    {
                        Id = p.Id,
                        Codigo = p.Codigo,
                        Nombre = p.Nombre,
                        Descripcion = p.Descripcion,
                        TipoProducto = p.TipoProducto,
                        Estado = p.Estado,
                        CantidadDisponible = p.CantidadDisponible + d.Cantidad
                    }).ToList();
        }
    }
}
