using System.Collections.Generic;
using System.Threading.Tasks;
using smstemp.Models;

namespace smstemp.Interfaces
{
    public interface Blazor_IrpteHistorico
    {
        Task<IEnumerable<rpteHistorico>> GetObtenerHistorico(string mobileCadena, string fechaInicio, string fechaFinal, int companyid);
    }
}
