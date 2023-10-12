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
            return Mapper.Map<ClienteDto>(repository.Get(e => 
            (e.Id == 0 || e.Id == filtro.Id) &&
            (string.IsNullOrEmpty(filtro.Nombre) || e.Nombre == filtro.Nombre) &&
            (string.IsNullOrEmpty(filtro.NumeroDocumento) || e.NumeroDocumento == filtro.NumeroDocumento) &&
            (string.IsNullOrEmpty(filtro.TipoDocumento) || e.TipoDocumento == filtro.TipoDocumento) &&
            (string.IsNullOrEmpty(filtro.Telefono) || e.Telefono == filtro.Telefono) &&
            (string.IsNullOrEmpty(filtro.Email) || e.Email == filtro.Email)
            ));           
        }

        public List<ClienteDto> ListClientes(ClienteDto filtro)
        {
            var repository = UnitOfWork.ClienteRepository();
            return Mapper.Map<List<ClienteDto>>(repository.List(e =>
            (e.Id == 0 || e.Id == filtro.Id) &&
            (string.IsNullOrEmpty(filtro.Nombre) || e.Nombre == filtro.Nombre) &&
            (string.IsNullOrEmpty(filtro.NumeroDocumento) || e.NumeroDocumento == filtro.NumeroDocumento) &&
            (string.IsNullOrEmpty(filtro.TipoDocumento) || e.TipoDocumento == filtro.TipoDocumento) &&
            (string.IsNullOrEmpty(filtro.Telefono) || e.Telefono == filtro.Telefono) &&
            (string.IsNullOrEmpty(filtro.Email) || e.Email == filtro.Email)
            ));
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
