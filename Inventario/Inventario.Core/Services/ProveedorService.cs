using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class ProveedorService : BaseService, IProveedorService
    {
        private readonly IMapper _mapper;

        public ProveedorService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public ProveedorDto DeleteProveedor(ProveedorDto proveedor)
        {
            var repository = UnitOfWork.ProveedorRepository();
            repository.Update(_mapper.Map<Proveedor>(proveedor));
            UnitOfWork.SaveChanges();
            return proveedor;
        }

        public ProveedorDto GetProveedor(ProveedorDto filtro)
        {
            var repository = UnitOfWork.ProveedorRepository();
            return _mapper.Map<ProveedorDto>(repository.Get(e => e.Id == filtro.Id));
        }

        public List<ProveedorDto> ListProveedores(ProveedorDto filtro)
        {
            var repository = UnitOfWork.ProveedorRepository();
            return _mapper.Map<List<ProveedorDto>>(repository.List(e => e.Id == filtro.Id));
        }

        public ProveedorDto SaveProveedor(ProveedorDto proveedor)
        {
            var repository = UnitOfWork.ProveedorRepository();
            var result = repository.Add(_mapper.Map<Proveedor>(proveedor));
            UnitOfWork.SaveChanges();
            return _mapper.Map<ProveedorDto>(result);
        }

        public ProveedorDto UpdateProveedor(ProveedorDto proveedor)
        {
            var repository = UnitOfWork.ProveedorRepository();
            var result = repository.Add(_mapper.Map<Proveedor>(proveedor));
            UnitOfWork.SaveChanges();
            return _mapper.Map<ProveedorDto>(result);
        }
    }
}
