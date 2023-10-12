
using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Dtos.Custom;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public UsuarioDto DeleteUsuario(UsuarioDto usuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioDetalleDto GetUsuario(UsuarioDto filtro)
        {
            var repository = UnitOfWork.UsuarioRepository();
            return repository.List(filtro).FirstOrDefault()!;
        }

        public List<UsuarioDetalleDto> ListUsuarios(UsuarioDto filtro)
        {
            var repository = UnitOfWork.UsuarioRepository();
            return repository.List(filtro);
        }

        public UsuarioDto SaveUsuario(UsuarioDto usuario)
        {
            var repository = UnitOfWork.UsuarioRepository();
            var result = repository.Add(Mapper.Map<Usuario>(usuario));
            UnitOfWork.SaveChanges();
            return Mapper.Map<UsuarioDto>(result);
        }

        public UsuarioDto UpdateUsuario(UsuarioDto usuario)
        {
            var repository = UnitOfWork.UsuarioRepository();
            var result = repository.Update(Mapper.Map<Usuario>(usuario));
            UnitOfWork.SaveChanges();
            return Mapper.Map<UsuarioDto>(result);
        }
    }
}
