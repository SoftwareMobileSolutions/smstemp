using System.Collections.Generic;
using System.Threading.Tasks;
using smstemp.Models;

namespace smstemp.Interfaces
{
    public interface Blazor_IrpteAlertasDiarias
    {
        Task<IEnumerable<rpteAlertasDiarias>> GetObtenerAlertasDiarias(int mobileid, string fecha, string fecha2, int RangoTiempo, int companyid);
    }
}
