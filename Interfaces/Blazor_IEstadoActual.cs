using smstemp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smstemp.Interfaces
{
    public interface Blazor_IEstadoActual
    {
        Task<IEnumerable<EstadoActual>> GetEstadoActual(int userid, int companyid, int bandera);
    }
}
