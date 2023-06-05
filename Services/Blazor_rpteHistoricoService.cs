using Dapper;
using smstemp.Data;
using smstemp.Interfaces;
using smstemp.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace smstemp.Services
{
    public class Blazor_rpteHistoricoService: Blazor_IrpteHistorico
    {
        //private readonly IHttpContextAccessor ctx;
        private readonly SqlCnConfigMain _configuration;
        public Blazor_rpteHistoricoService(SqlCnConfigMain configuration)
        {
            _configuration = configuration;
            //ctx = httpContextAccessor;
        }

        public async Task<IEnumerable<rpteHistorico>> GetObtenerHistorico(string mobileCadena, string fechaInicio, string fechaFinal, int companyid)
        {
            IEnumerable<rpteHistorico> DataEX;
            /*
            SqlCnUrl SqlCnUrl = new SqlCnUrl(ctx);
            string conexion = SqlCnUrl.getCon(0);
            */
            //using (var conn = new SqlConnection(conexion))
            using (var conn = new SqlConnection(_configuration.Value))
            {
                string query = @"exec SP_SMSTemp_ObtenerLineaGraficoHistorico_Des @mobileCadena,@fechaInicio,@fechaFinal,@companyid";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    DataEX = await conn.QueryAsync<rpteHistorico>(query, new { mobileCadena, fechaInicio, fechaFinal, companyid }, commandType: CommandType.Text);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }

            }
            return DataEX;
        }
    }
}
