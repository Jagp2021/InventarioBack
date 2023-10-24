using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public ClienteDto DeleteCliente(ClienteDto cliente)
        {
            var repository = UnitOfWork.ClienteRepository();
            repository.Update(Mapper.Map<Cliente>(cliente));
            UnitOfWork.SaveChanges();
            return cliente;
        }

        public ClienteDto GetCliente(ClienteDto filtro)
        {
            var repository = UnitOfWork.ClienteRepository();
            return Mapper.Map<ClienteDto>(repository.List(filtro).FirstOrDefault()!);           
        }

        public List<ClienteDto> ListClientes(ClienteDto filtro)
        {
            var repository = UnitOfWork.ClienteRepository();
            return Mapper.Map<List<ClienteDto>>(repository.List(filtro));
        }

        public ClienteDto SaveCliente(ClienteDto cliente)
        {
            var repository = UnitOfWork.ClienteRepository();
            var result = repository.Add(Mapper.Map<Cliente>(cliente));
            UnitOfWork.SaveChanges();
            return Mapper.Map<ClienteDto>(result);
        }

        public ClienteDto UpdateCliente(ClienteDto cliente)
        {
            var repository = UnitOfWork.ClienteRepository();
            var result = repository.Update(Mapper.Map<Cliente>(cliente));
            UnitOfWork.SaveChanges();
            return Mapper.Map<ClienteDto>(result);
        }
    }
}
