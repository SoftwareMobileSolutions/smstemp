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
    public class Blazor_rpteMensualService : Blazor_IrpteMensual
    {
        //private readonly IHttpContextAccessor ctx;
        private readonly SqlCnConfigMain _configuration;
        public Blazor_rpteMensualService(SqlCnConfigMain configuration/*IHttpContextAccessor httpContextAccessor*/)
        {
            _configuration = configuration;
            //ctx = httpContextAccessor;
        }

        public async Task<IEnumerable<rpteMensual>> GetObtenerMensualMin(int mes, int anio, int companyid, int bandera, string mobileCadena)
        {  
            IEnumerable<rpteMensual> DataEX;
            /*
          
            SqlCnUrl SqlCnUrl = new SqlCnUrl(ctx); 
            string conexion = SqlCnUrl.getCon(0);
            */

            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"exec SP_SMSTemp_ObtenerReporteMensualGrafico @mes,@anio,@companyid,@bandera,@mobileCadena";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    DataEX = await conn.QueryAsync<rpteMensual>(query, new { mes, anio, companyid, bandera, mobileCadena }, commandType: CommandType.Text);

                }

                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

            }
            return DataEX;
        }

        public async Task<IEnumerable<rpteMensual>> GetObtenerMensualMax(int mes, int anio, int companyid, int bandera, string mobileCadena)
        {
            IEnumerable<rpteMensual> DataEX;
            /*
            SqlCnUrl SqlCnUrl = new SqlCnUrl(ctx);
            string conexion = SqlCnUrl.getCon(0);
            */
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"exec SP_SMSTemp_ObtenerReporteMensualGraficoMax @mes,@anio,@companyid,@bandera,@mobileCadena";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    DataEX = await conn.QueryAsync<rpteMensual>(query, new { mes, anio, companyid, bandera, mobileCadena }, commandType: CommandType.Text);

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

            }
            return DataEX;
        }
        public async Task<IEnumerable<grafMensual>> GetObtenerMensualGraf(int mes, int anio, int companyid, int bandera, string mobileCadena)
        {
            IEnumerable<grafMensual> DataEX;
            /*
            SqlCnUrl SqlCnUrl = new SqlCnUrl(ctx);
            string conexion = SqlCnUrl.getCon(0);
            */
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"exec SP_SMSTemp_ObtenerReporteMensualGrafico @mes,@anio,@companyid,@bandera,@mobileCadena";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    DataEX = await conn.QueryAsync<grafMensual>(query, new { mes, anio, companyid, bandera, mobileCadena }, commandType: CommandType.Text);

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

            }
            return DataEX;
        }
        public async Task<IEnumerable<grafMensual>> GetObtenerMensualGrafMax(int mes, int anio, int companyid, int bandera, string mobileCadena)
        {
            IEnumerable<grafMensual> DataEX;
            /*
            SqlCnUrl SqlCnUrl = new SqlCnUrl(ctx);
            string conexion = SqlCnUrl.getCon(0);
            */
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"exec SP_SMSTemp_ObtenerReporteMensualGraficoMax @mes,@anio,@companyid,@bandera,@mobileCadena";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    DataEX = await conn.QueryAsync<grafMensual>(query, new { mes, anio, companyid, bandera, mobileCadena }, commandType: CommandType.Text);

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

            }
            return DataEX;
        }
        public async Task<IEnumerable<grafSeries>> GetObtenerMensualGrafSerie(int mes, int anio, int companyid, int bandera, string mobileCadena)
        {
            IEnumerable<grafSeries> DataEX;
            /* SqlCnUrl SqlCnUrl = new SqlCnUrl(ctx);
             string conexion = SqlCnUrl.getCon(0);

             using (var conn = new SqlConnection(conexion))
                 */
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"exec SP_SMSTemp_ObtenerReporteMensualGrafico @mes,@anio,@companyid,@bandera,@mobileCadena";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    DataEX = await conn.QueryAsync<grafSeries>(query, new { mes, anio, companyid, bandera, mobileCadena }, commandType: CommandType.Text);

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

            }
            return DataEX;
        }
        public async Task<IEnumerable<grafSeries>> GetObtenerMensualGrafMaxSerie(int mes, int anio, int companyid, int bandera, string mobileCadena)
        {
            IEnumerable<grafSeries> DataEX;
            /* SqlCnUrl SqlCnUrl = new SqlCnUrl(ctx);
             string conexion = SqlCnUrl.getCon(0);
             using (var conn = new SqlConnection(conexion))
                 */
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"exec SP_SMSTemp_ObtenerReporteMensualGraficoMax @mes,@anio,@companyid,@bandera,@mobileCadena";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    DataEX = await conn.QueryAsync<grafSeries>(query, new { mes, anio, companyid, bandera, mobileCadena }, commandType: CommandType.Text);

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
