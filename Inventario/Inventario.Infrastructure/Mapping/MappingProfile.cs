using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;

namespace Inventario.Infrastructure.Mapping
{
    /// <summary>
    /// Fecha: 24 de Febrero de 2023
    /// Descripción: Clase que define los mapeos entre DTO y Entidad
    /// Autor: Javier Gonzalez
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Producto
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>();
            #endregion

            #region Cliente
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();
            #endregion

            #region Usuario
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<UsuarioDetalleDto, Usuario>();
            CreateMap<Usuario, UsuarioDetalleDto>();
            #endregion

            #region Proveedor
            CreateMap<ProveedorDto, Proveedor>();
            CreateMap<Proveedor, ProveedorDto>();
            #endregion

            #region Garantia
            CreateMap<Garantia, GarantiaDto>();
            CreateMap<GarantiaDto, Garantia>();
            CreateMap<DetalleGarantia, DetalleGarantiaDto>();
            CreateMap<DetalleGarantiaDto, DetalleGarantia>();
            CreateMap<GarantiaDetalleDto, Garantia>()
                .ForMember(dest => dest.DetalleGarantia, opt => opt.MapFrom(src => src.DetalleGarantia));
            CreateMap<Garantia, GarantiaDetalleDto>()
                .ForMember(dest => dest.DetalleGarantia, opt => opt.MapFrom(src => src.DetalleGarantia));
            CreateMap<DetalleGarantiaDto, Producto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdProducto));
            #endregion

            #region Ingreso
            CreateMap<Ingreso, IngresoDetalleDto>();
            CreateMap<DetalleIngresoDto, DetalleIngreso>();
            CreateMap<DetalleIngreso, DetalleIngresoDto>();       
            CreateMap<IngresoDetalleDto, Ingreso>()
                .ForMember(dest => dest.DetalleIngresos, opt => opt.MapFrom(src => src.DetalleIngreso));
            CreateMap<DetalleIngresoDto, Producto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdProducto));
            #endregion

            #region Venta
            CreateMap<DetalleVentaDetalleDto, DetalleVenta>();
            CreateMap<DetalleVenta, DetalleVentaDetalleDto>();
            CreateMap<DetalleVentaDto, DetalleVenta>();
            CreateMap<DetalleVenta, DetalleVentaDto>();
            CreateMap<VentaDto, Venta>();
            CreateMap<Venta, VentaDto>();
            CreateMap<VentaDetalleDto, Venta>()
               .ForMember(dest => dest.DetalleFactura, opt => opt.MapFrom(src => src.DetalleFactura));
            CreateMap<Venta, VentaDetalleDto>()
                .ForMember(dest => dest.DetalleFactura, opt => opt.MapFrom(src => src.DetalleFactura));
            CreateMap<DetalleVentaDto, Producto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdProducto));
            #endregion

            #region Dominio

            CreateMap<Dominio, DominioDto>();
            CreateMap<DominioDto, Dominio>();
            CreateMap<Perfil, PerfilDto>();
            CreateMap<PerfilDto, Perfil>();
            #endregion
        }
    }
}
