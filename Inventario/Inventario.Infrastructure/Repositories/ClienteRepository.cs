using Inventario.Core.Dtos.Custom;
using Inventario.Core.Dtos;
using Inventario.Core.Entities;
using Inventario.Core.Interfaces.Repository;
using Inventario.Infrastructure.Context;
using Inventario.Core.Utils;

namespace Inventario.Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly EFContext _dbContext;

        public ClienteRepository(EFContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ClienteDetalleDto> List(ClienteDto filtro)
        {
            return (from c in _dbContext.Clientes
                    select new ClienteDetalleDto { 
                     DescripcionTipoDocumento = _dbContext.Dominios.FirstOrDefault(e => e.Dominio1 == Constants.Dominio.DOMINIO_TIPO_DOCUMENTO && e.Sigla == c.TipoDocumento)!.Descripcion,
                     TipoDocumento = c.TipoDocumento,
                     NumeroDocumento = c.NumeroDocumento,
                     Nombre = c.Nombre,
                     Email = c.Email,
                     Telefono = c.Telefono,
                     Id = c.Id
                    }).ToList();
        }
    }
}
