using System.Collections.Generic;
using System.Threading.Tasks;
using smstemp.Models;

namespace smstemp.Interfaces
{
    public interface Blazor_IrpteMensual
    {
        Task<IEnumerable<rpteMensual>> GetObtenerMensualMin(int mes, int anio, int companyid, int bandera, string mobileCadena);
        Task<IEnumerable<rpteMensual>> GetObtenerMensualMax(int mes, int anio, int companyid, int bandera, string mobileCadena);
        Task<IEnumerable<grafMensual>> GetObtenerMensualGraf(int mes, int anio, int companyid, int bandera, string mobileCadena);
        Task<IEnumerable<grafMensual>> GetObtenerMensualGrafMax(int mes, int anio, int companyid, int bandera, string mobileCadena);
        Task<IEnumerable<grafSeries>> GetObtenerMensualGrafSerie(int mes, int anio, int companyid, int bandera, string mobileCadena);
        Task<IEnumerable<grafSeries>> GetObtenerMensualGrafMaxSerie(int mes, int anio, int companyid, int bandera, string mobileCadena);
    }
}
