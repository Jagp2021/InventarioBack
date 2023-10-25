using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;

namespace Inventario.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly EFContext _context;
        public UsuarioRepository(EFContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public List<UsuarioDetalleDto> List(UsuarioDto filtro)
        {
            return (from u in _context.Usuarios
                    join p in _context.Perfils on u.IdPerfil equals p.Id
                    where (filtro.Id == 0 || u.Id == filtro.Id) &&
                          (filtro.IdPerfil == 0 || u.IdPerfil == filtro.IdPerfil) &&
                          (string.IsNullOrEmpty(filtro.Username) || u.Username == filtro.Username) &&
                          (string.IsNullOrEmpty(filtro.Email) || u.Email == filtro.Email) &&
                          (string.IsNullOrEmpty(filtro.Nombre) || u.Nombre == filtro.Nombre) &&
                          (string.IsNullOrEmpty(filtro.NumeroDocumento) || u.NumeroDocumento == filtro.NumeroDocumento) &&
                          (string.IsNullOrEmpty(filtro.Telefono) || u.Telefono == filtro.Telefono) &&
                          (string.IsNullOrEmpty(filtro.TipoDocumento) || u.TipoDocumento == filtro.TipoDocumento)
                    select new UsuarioDetalleDto
                    {
                        Id = u.Id,
                        Username = u.Username,
                        Password = u.Password,
                        IdPerfil = u.IdPerfil,
                        DescripcionPerfil = p.Nombre,
                        Email = u.Email,
                        Nombre = u.Nombre,
                        NumeroDocumento = u.NumeroDocumento,
                        Telefono = u.Telefono,
                        TipoDocumento = u.TipoDocumento,
                        DescripcionTipoDocumento = ""

                    }).ToList();
        }
    }
}
