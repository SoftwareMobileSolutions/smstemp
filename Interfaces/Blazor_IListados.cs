using System.Collections.Generic;
using System.Threading.Tasks;
using smstemp.Models;

namespace smstemp.Interfaces
{
    public interface Blazor_IListados
    {
        Task<IEnumerable<Listados>> GetListados(int userid, int companyid, int subfleetid, int bandera);
        Task<IEnumerable<Arbol>> GetArbol(int userid, int companyid, int subfleetid, int bandera);
    }
}
