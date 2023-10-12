using AutoMapper;
using Inventario.Core.Dtos;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Core.Interfaces.Service;

namespace Inventario.Core.Services
{
    public class ProveedorService : BaseService, IProveedorService
    {

        public ProveedorService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public ProveedorDto DeleteProveedor(ProveedorDto proveedor)
        {
            var repository = UnitOfWork.ProveedorRepository();
            repository.Update(Mapper.Map<Proveedor>(proveedor));
            UnitOfWork.SaveChanges();
            return proveedor;
        }

        public ProveedorDto GetProveedor(ProveedorDto filtro)
        {
            var repository = UnitOfWork.ProveedorRepository();
            return Mapper.Map<ProveedorDto>(repository.Get(e => e.Id == filtro.Id));
        }

        public List<ProveedorDto> ListProveedores(ProveedorDto filtro)
        {
            var repository = UnitOfWork.ProveedorRepository();
            return Mapper.Map<List<ProveedorDto>>(repository.List(e => e.Id == filtro.Id));
        }

        public ProveedorDto SaveProveedor(ProveedorDto proveedor)
        {
            var repository = UnitOfWork.ProveedorRepository();
            var result = repository.Add(Mapper.Map<Proveedor>(proveedor));
            UnitOfWork.SaveChanges();
            return Mapper.Map<ProveedorDto>(result);
        }

        public ProveedorDto UpdateProveedor(ProveedorDto proveedor)
        {
            var repository = UnitOfWork.ProveedorRepository();
            var result = repository.Update(Mapper.Map<Proveedor>(proveedor));
            UnitOfWork.SaveChanges();
            return Mapper.Map<ProveedorDto>(result);
        }
    }
}
