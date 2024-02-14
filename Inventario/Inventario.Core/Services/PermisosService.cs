using AutoMapper;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;
using System.Runtime.InteropServices;

namespace Inventario.Core.Services
{
    public class PermisosService : BaseService, IPermisosService
    {
        public PermisosService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public SesionDto ValidarSesion(string usuario, string contrasena)
        {
            var usuarioActual = UnitOfWork.BaseRepository<Usuario>().Get(x => x.Username == usuario && x.Password == contrasena) ?? throw new ExternalException("Usuario o contraseña incorrecta");
            var perfil = UnitOfWork.BaseRepository<Perfil>().Get(x => x.Id == usuarioActual.IdPerfil) ?? throw new ExternalException("Perfil no encontrado");
            return new SesionDto
            {
                IdUsuario = usuarioActual.Id,
                NombreUsuario = usuarioActual.Nombre,
                RolUsuario = perfil.Nombre
            };
        }

        public List<MenuDto> ListarMenu(int idUsuario)
        {
            var perfil = UnitOfWork.BaseRepository<Usuario>().Get(x => x.Id == idUsuario)!.IdPerfil;
            var permisos = UnitOfWork.BaseRepository<PermisosPerfil>().List(x => x.IdPerfil == perfil );
            var menus = UnitOfWork.BaseRepository<Menu>().List(x => permisos.Select(e => e.IdMenu).Contains(x.Id));
            return GenerarArbolMenu(menus);
        }

        

        private static List<MenuDto> GenerarArbolMenu(List<Menu> menus)
        {
            var menuRaiz = menus.Where(e => e.IdMenuPadre == null).OrderBy(e => e.Id).Select(e =>
                new MenuDto
                {
                    Icon = e.Icono,
                    Label = e.Nombre,
                    RouterLink = GenerarRouterLink(e),
                    Items = GenerarHijosArbol(menus, e),
                }
            );

            return menuRaiz.Where(e => e.Items!.Any()).ToList();
        }

        private static List<MenuDto> GenerarHijosArbol(List<Menu> menus, Menu menu)
        {
            var hijos = menus.Where(e => e.IdMenuPadre == menu.Id).OrderBy(e => e.Id).Select(e =>
                new MenuDto
                {
                    Icon = e.Icono,
                    Label = e.Nombre,
                    RouterLink = GenerarRouterLink(e),
                    Items = GenerarHijosArbol(menus, e),
                }
            );

            return hijos.Where(e => e.Items!.Any() || e.RouterLink != null).ToList();
        }

        private static List<object>? GenerarRouterLink(Menu menu)
        {
            var routerLink = new List<object>();
            if (!string.IsNullOrEmpty(menu.Url))
            {
                routerLink.Add(menu.Url!);
            }

            return routerLink.Any() ? routerLink : null;
        }       
    }
}
