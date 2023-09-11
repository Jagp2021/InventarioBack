using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IMapper _mapper;
        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public ClienteDto DeleteCliente(ClienteDto cliente)
        {
            var repository = UnitOfWork.ClienteRepository();
            repository.Update(_mapper.Map<Cliente>(cliente));
            UnitOfWork.SaveChanges();
            return cliente;
        }

        public ClienteDto GetCliente(ClienteDto filtro)
        {
            var repository = UnitOfWork.ClienteRepository();
            return _mapper.Map<ClienteDto>(repository.Get(e => e.Id == filtro.Id));           
        }

        public List<ClienteDto> ListClientes(ClienteDto filtro)
        {
            var repository = UnitOfWork.ClienteRepository();
            return _mapper.Map<List<ClienteDto>>(repository.List(e => e.Id == filtro.Id));
        }

        public ClienteDto SaveCliente(ClienteDto cliente)
        {
            var repository = UnitOfWork.ClienteRepository();
            var result = repository.Add(_mapper.Map<Cliente>(cliente));
            UnitOfWork.SaveChanges();
            return _mapper.Map<ClienteDto>(result);
        }

        public ClienteDto UpdateCliente(ClienteDto cliente)
        {
            var repository = UnitOfWork.ClienteRepository();
            var result = repository.Update(_mapper.Map<Cliente>(cliente));
            UnitOfWork.SaveChanges();
            return _mapper.Map<ClienteDto>(result);
        }
    }
}
