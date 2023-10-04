using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Dtos.Custom
{
    public class ClienteDetalleDto : ClienteDto
    {
        public string? DescripcionTipoDocumento { get; set; }
    }
}
