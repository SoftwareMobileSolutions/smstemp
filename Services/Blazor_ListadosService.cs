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
    public class Blazor_ListadosService: Blazor_IListados
    {
        private readonly SqlCnConfigMain _configuration;
        public Blazor_ListadosService(SqlCnConfigMain configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<Listados>> GetListados(int userid, int companyid, int subfleetid, int bandera)
        {
            /*
            SqlCnUrl SqlCnUrl = new SqlCnUrl(ctx);
            string conexion = SqlCnUrl.getCon(0);
            */
            IEnumerable<Listados> DataEX;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"exec SP_SMSTemp_ObtenerListados @userid,@companyid,@subfleetid,@bandera";

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                try
                {
                    DataEX = await conn.QueryAsync<Listados>(query, new { userid, companyid, subfleetid, bandera }, commandType: CommandType.Text);

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

            }
            return DataEX;
        }
        public async Task<IEnumerable<Arbol>> GetArbol(int userid, int companyid, int subfleetid, int bandera)
        {
            /*
            SqlCnUrl SqlCnUrl = new SqlCnUrl(ctx);
            string conexion = SqlCnUrl.getCon(0);
            */
            IEnumerable<Arbol> DataEX;
            //using (var conn = new SqlConnection(conexion))
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"exec SP_SMSTemp_ObtenerListados @userid,@companyid,@subfleetid,@bandera";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    DataEX = await conn.QueryAsync<Arbol>(query, new { userid, companyid, subfleetid, bandera }, commandType: CommandType.Text);

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
