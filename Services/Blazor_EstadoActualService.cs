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
using smstemp.Data;

namespace smstemp.Services
{
    public class Blazor_EstadoActualService: Blazor_IEstadoActual
    {
        private readonly SqlCnConfigMain _configuration;
        public Blazor_EstadoActualService(SqlCnConfigMain configuration)
        {
            _configuration = configuration;
        }
        /*
        private readonly IHttpContextAccessor ctx;
        public Blazor_EstadoActualService(IHttpContextAccessor httpContextAccessor)
        {
            ctx = httpContextAccessor;
        }
        */
        public async Task<IEnumerable<EstadoActual>> GetEstadoActual(int userid, int companyid, int bandera)
        {
            IEnumerable<EstadoActual> DataEX;


            using (var conn = new SqlConnection(_configuration.Value))
            {
                string query = @"exec SP_SMSTemp_EstadoActual @userid,@companyid,@bandera";

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                   
                try
                {
                    DataEX = await conn.QueryAsync<EstadoActual>(query, new { userid, companyid, bandera }, commandType: CommandType.Text);

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
    }
}
