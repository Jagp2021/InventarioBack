using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Entities;

namespace Inventario.Infrastructure.Mapping
{
    /// <summary>
    /// Fecha: 24 de Febrero de 2023
    /// Descripción: Clase que define los mapeos entre DTO y Entidad
    /// Autor: Asesoftware - Javier Gonzalez
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>();          
        }
    }
}
