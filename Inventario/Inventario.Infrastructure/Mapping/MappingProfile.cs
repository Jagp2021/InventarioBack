using AutoMapper;
using Inventario.Core.Dtos;
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
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>();  
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();
            CreateMap<ProductoDto, Producto>();
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProveedorDto, Proveedor>();
            CreateMap<Proveedor, ProveedorDto>();
        }
    }
}
