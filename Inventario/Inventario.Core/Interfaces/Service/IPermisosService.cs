using Inventario.Core.Dtos.Custom;

namespace Inventario.Core.Interfaces.Service
{
    public interface IPermisosService
    {
        SesionDto ValidarSesion(string usuario, string contrasena);

        List<MenuDto> ListarMenu(int idUsuario);
    }
}
