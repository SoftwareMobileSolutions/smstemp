using smstemp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smstemp.Interfaces
{
    public interface Blazor_IAdminAlarmas
    {
        Task<IEnumerable<AdminAlarmas_Obtener>> GetObtenerAlarmas(int userid, int companyid);
        Task<bool> InsertarAlertas(int mobileid,
        int s1Min, int s1Max, int s2Min, int s2Max, int s3Min,
        int s3Max, int s4Min, int s4Max, int s5Min, int s5Max,
        int s6Min, int s6Max, DateTime HoraInicio, DateTime HoraFinal,
        int companyid, int lun, int mar, int mie, int jue,
        int vie, int sab, int dom, int tiempoAlarma);

        Task<bool> ActualizarAlertas(int AlarmaTempid, int mobileid,
       int s1Min, int s1Max, int s2Min, int s2Max, int s3Min,
       int s3Max, int s4Min, int s4Max, int s5Min, int s5Max,
       int s6Min, int s6Max, DateTime HoraInicio, DateTime HoraFinal, int alarma,
       int companyid, int lun, int mar, int mie, int jue,
       int vie, int sab, int dom, int tiempoAlarma);
    }
}
