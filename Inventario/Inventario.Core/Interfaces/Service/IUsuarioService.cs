using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;

namespace Inventario.Core.Interfaces.Service
{
    public interface IUsuarioService
    {
        List<UsuarioDetalleDto> ListUsuarios(UsuarioDto filtro);
        UsuarioDetalleDto GetUsuario(UsuarioDto filtro);
        UsuarioDto SaveUsuario(UsuarioDto usuario);
        UsuarioDto UpdateUsuario(UsuarioDto usuario);
        UsuarioDto DeleteUsuario(UsuarioDto usuario);
    }
}
