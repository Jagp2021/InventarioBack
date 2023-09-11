using Inventario.Core.Dtos;

namespace Inventario.Core.Interfaces.Service
{
    public interface IClienteService
    {
        List<ClienteDto> ListClientes(ClienteDto filtro);
        ClienteDto GetCliente(ClienteDto filtro);
        ClienteDto SaveCliente(ClienteDto cliente);
        ClienteDto UpdateCliente(ClienteDto cliente);
        ClienteDto DeleteCliente(ClienteDto cliente);
    }
}
