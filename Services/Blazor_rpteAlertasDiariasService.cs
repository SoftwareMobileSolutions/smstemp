using Dapper;
using smstemp.Data;
using smstemp.Interfaces;
using smstemp.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace smstemp.Services
{
    public class Blazor_rpteAlertasDiariasService: Blazor_IrpteAlertasDiarias
    {
        private readonly SqlCnConfigMain _configuration;
        public Blazor_rpteAlertasDiariasService(SqlCnConfigMain configuration)
        {
            _configuration = configuration;
            // ctx = httpContextAccessor;
        }

        public async Task<IEnumerable<rpteAlertasDiarias>> GetObtenerAlertasDiarias(int mobileid, string fecha, string fecha2, int RangoTiempo, int companyid)
        {
            /*
            SqlCnUrl SqlCnUrl = new SqlCnUrl(ctx);
            string conexion = SqlCnUrl.getCon(0);
            */
            IEnumerable<rpteAlertasDiarias> DataEX;
            //using (var conn = new SqlConnection(conexion))
            using (var conn = new SqlConnection(_configuration.Value))
            {

                const string query = @"exec SP_SMSTemp_ObtenerDatosGrafico @mobileid,@fecha,@fecha2,@RangoTiempo,@companyid";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    DataEX = await conn.QueryAsync<rpteAlertasDiarias>(query, new { mobileid, fecha, fecha2, RangoTiempo, companyid }, commandType: CommandType.Text);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

            }
            return DataEX;
        }
    }
}
