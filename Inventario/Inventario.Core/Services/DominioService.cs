using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class DominioService : BaseService, IDominioService
    {
        public DominioService(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork, mapper)
        {

        }

        public List<DominioDto> ListDominios(DominioDto filtro)
        {
            var repository = UnitOfWork.BaseRepository<Dominio>();
            var dominios = repository.List(e => string.IsNullOrEmpty(filtro.Dominio1) || e.Dominio1 == filtro.Dominio1);
            return Mapper.Map<List<DominioDto>>(dominios);
        }

        public List<PerfilDto> ListPerfiles()
        {
            var repository = UnitOfWork.BaseRepository<Perfil>();
            var perfiles = repository.List(e => e.Id != 0);
            return Mapper.Map<List<PerfilDto>>(perfiles);
        }
    }
}
