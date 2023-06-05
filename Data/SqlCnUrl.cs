using Microsoft.AspNetCore.Http;
using smstemp.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using smstemp.Models;
using System.Linq;
using smstemp.Util;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace smstemp.Data
{

    public  class SqlCnUrl
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private  readonly IHttpContextAccessor ctx;

        public SqlCnUrl(IHttpContextAccessor httpContextAccessor, IConfiguration configuration = null)
        {
            ctx = httpContextAccessor;
        }
    

        public string getCon(int tipo)
        {

            return "Server=10.0.0.5; Database=FleetManager; User ID=mantenimiento; Password=mttofleet; Trusted_Connection=false; MultipleActiveResultSets=true;";

            /*string urlPage = getUrlPortalID();
            string sessionIdBD = "dataPortalConection" + "-" + urlPage + "-" + tipo.ToString();
            var conexion = _Session.Get<IEnumerable<_SqlCnConfigMainModel>>(ctx.HttpContext.Session, sessionIdBD);
            if (conexion.Count() > 0)
            {
                var cn = conexion.ToList()[0];
                return "Server=" + cn.source + "; Database=" + cn.catalog + "; User ID=" + cn.user + "; Password=" + cn.pass + "; Trusted_Connection=false; MultipleActiveResultSets=true;";
            }*/
           // return null;
        }
        
    

        //Funciones solo para el login y evitar setear en la session la conexión desde sin loguearse
      

       
    }
}
