using Inventario.Core.Dtos;

namespace Inventario.Core.Interfaces.Service
{
    public interface IProveedorService
    {
        List<ProveedorDto> ListProveedores(ProveedorDto filtro);
        ProveedorDto GetProveedor(ProveedorDto filtro);
        ProveedorDto SaveProveedor(ProveedorDto proveedor);
        ProveedorDto UpdateProveedor(ProveedorDto proveedor);
        ProveedorDto DeleteProveedor(ProveedorDto proveedor);
    }
}
