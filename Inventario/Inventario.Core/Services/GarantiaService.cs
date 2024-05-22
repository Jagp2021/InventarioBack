using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;
using Inventario.Core.Utils;

namespace Inventario.Core.Services
{
    public class GarantiaService : BaseService, IGarantiaService
    {
        public GarantiaService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public List<GarantiaDetalleDto> ListGarantias(GarantiaDetalleDto filtro)
        {
            var repository = UnitOfWork.GarantiaRepository();
            return Mapper.Map<List<GarantiaDetalleDto>>(repository.ListDetalle(filtro));
        }

        public GarantiaDetalleDto SaveGarantia(GarantiaDetalleDto garantia, string accion)
        {
            var repository = UnitOfWork.GarantiaRepository();
            var productoRepository = UnitOfWork.ProductoRepository();
            var productos = productoRepository.ListProductosAsociados(Mapper.Map<List<Producto>>(garantia.DetalleGarantia));
            if (accion == Constants.General.ACCION_GUARDAR)
            {
                repository.Add(Mapper.Map<Garantia>(garantia));
            }
            else
            {
                repository.Update(Mapper.Map<Garantia>(garantia));
            }

            switch (garantia.TipoGarantia)
            {
                case Constants.Dominio.TipoGarantia.VENTA:
                    if (garantia.EstadoGarantia == Constants.Dominio.EstadoGarantia.GESTIONADA)
                    {
                        productoRepository.UpdateRange(ActualizarInventario(productos, garantia.DetalleGarantia!, true));
                    }
                    break;
                case Constants.Dominio.TipoGarantia.INGRESO:
                    if (garantia.EstadoGarantia == Constants.Dominio.EstadoGarantia.REGISTRADA)
                    {
                        productoRepository.UpdateRange(ActualizarInventario(productos, garantia.DetalleGarantia!, false));
                    }
                    if (garantia.EstadoGarantia == Constants.Dominio.EstadoGarantia.GESTIONADA)
                    {
                        productoRepository.UpdateRange(ActualizarInventario(productos, garantia.DetalleGarantia!, true));
                    }

                    break;
            }

            UnitOfWork.SaveChanges();
            return Mapper.Map<GarantiaDetalleDto>(garantia);
        }

        private static List<Producto> ActualizarInventario(List<Producto> productos, List<DetalleGarantiaDto> detalleGarantia, bool sumar)
        {
            return (from p in productos
                    join d in detalleGarantia on p.Id equals d.IdProducto
                    select new Producto
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                        Descripcion = p.Descripcion,
                        TipoProducto = p.TipoProducto,
                        Estado = p.Estado,
                        CantidadDisponible = sumar ? p.CantidadDisponible + d.Cantidad : p.CantidadDisponible - d.Cantidad,
                        Codigo = p.Codigo
                    }).ToList();
        }
    }
}
