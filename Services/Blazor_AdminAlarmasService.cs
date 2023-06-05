using Dapper;
using smstemp.Data;
using smstemp.Interfaces;
using smstemp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace smstemp.Services
{
    public class Blazor_AdminAlarmasService: Blazor_IAdminAlarmas
    {
        private readonly SqlCnConfigMain _configuration;
        public Blazor_AdminAlarmasService(SqlCnConfigMain configuration)
        {
            _configuration = configuration;
        }

        /*
        private readonly IHttpContextAccessor ctx;
        public Blazor_AdminAlarmasService(IHttpContextAccessor httpContextAccessor)
        {
            ctx = httpContextAccessor;
        }*/

        public async Task<IEnumerable<AdminAlarmas_Obtener>> GetObtenerAlarmas(int userid, int companyid)
        {
          

            IEnumerable<AdminAlarmas_Obtener> DataEX;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                string query = @"exec SP_SMSTemp_ObtenerAlarmas @userid,@companyid";
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                try
                {
                    DataEX = await conn.QueryAsync<AdminAlarmas_Obtener>(query, new { userid, companyid }, commandType: CommandType.Text);

                }

                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                }
            }
            return DataEX;
        }

        public async Task<bool> InsertarAlertas(int @mobileid,
        int @s1Min,
        int @s1Max,
        int @s2Min,
        int @s2Max,
        int @s3Min,
        int @s3Max,
        int @s4Min,
        int @s4Max,
        int @s5Min,
        int @s5Max,
        int @s6Min,
        int @s6Max,
        DateTime @HoraInicio,
        DateTime @HoraFinal,
        int @companyid,
        int @lun,
        int @mar,
        int @mie,
        int @jue,
        int @vie,
        int @sab,
        int @dom,
        int @tiempoAlarma)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                string query = @"exec SP_SMSTemp_InsertarAlarmas @mobileid ,
                @s1Min,
                @s1Max,
                @s2Min,
                @s2Max,
                @s3Min,
                @s3Max,
                @s4Min,
                @s4Max,
                @s5Min,
                @s5Max,
                @s6Min,
                @s6Max,
                @HoraInicio,
                @HoraFinal,
                @companyid,
                @lun,
                @mar,
                @mie,
                @jue,
                @vie,
                @sab,
                @dom,
                @tiempoAlarma";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new
                    {
                        mobileid,
                        s1Min,
                        s1Max,
                        s2Min,
                        s2Max,
                        s3Min,
                        s3Max,
                        s4Min,
                        s4Max,
                        s5Min,
                        s5Max,
                        s6Min,
                        s6Max,
                        HoraInicio,
                        HoraFinal,
                        companyid,
                        lun,
                        mar,
                        mie,
                        jue,
                        vie,
                        sab,
                        dom,
                        tiempoAlarma
                    }, commandType: CommandType.Text);
                    return true;
                }

                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                        
                }
            }

        }

        public async Task<bool> ActualizarAlertas(
       int AlarmaTempid, int mobileid,
       int s1Min, int s1Max, int s2Min, int s2Max, int s3Min,
       int s3Max, int s4Min, int s4Max, int s5Min, int s5Max,
       int s6Min, int s6Max, DateTime HoraInicio, DateTime HoraFinal, int alarma,
       int companyid, int lun, int mar, int mie, int jue,
       int vie, int sab, int dom, int tiempoAlarma
            )
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"exec SP_SMSTemp_ActualizarAlarmas @AlarmaTempid,@mobileid ,
                @s1Min,
                @s1Max,
                @s2Min,
                @s2Max,
                @s3Min,
                @s3Max,
                @s4Min,
                @s4Max,
                @s5Min,
                @s5Max,
                @s6Min,
                @s6Max,
                @HoraInicio,
                @HoraFinal,
                @alarma,
                @companyid,
                @lun,
                @mar,
                @mie,
                @jue,
                @vie,
                @sab,
                @dom,
                @tiempoAlarma";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new
                    {
                        AlarmaTempid,
                        mobileid,
                        s1Min,
                        s1Max,
                        s2Min,
                        s2Max,
                        s3Min,
                        s3Max,
                        s4Min,
                        s4Max,
                        s5Min,
                        s5Max,
                        s6Min,
                        s6Max,
                        HoraInicio,
                        HoraFinal,
                        alarma,
                        companyid,
                        lun,
                        mar,
                        mie,
                        jue,
                        vie,
                        sab,
                        dom,
                        tiempoAlarma
                    }, commandType: CommandType.Text);
                    return true;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

        }
    }
}

