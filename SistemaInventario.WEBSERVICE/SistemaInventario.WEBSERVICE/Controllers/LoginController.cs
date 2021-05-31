using BAZ.GEN.Log4Dan;
using SistemaInventario.DATOS;
using SistemaInventario.ENTITY.Parametros;
using SistemaInventario.WEBSERVICE.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//Controlador API vacío... MVP2
namespace SistemaInventario.WEBSERVICE.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private DALogin dalogin;
        //Se agrega la referencia de la carpeta UTIL
        private Log Log = new Log(typeof(LoginController));

        public LoginController()
        {
            dalogin = new DALogin();
        }
                
        [HttpPost]
        [Route("Acceder")]
        public IHttpActionResult Acceder(ENLogin paramss)
        {
            try
            {
                var ex = "";

                if(paramss == null)
                {
                    ex = "No se enviaron datos desde la web";
                    Log.WriteLogError(ex);
                }

                var rpt = dalogin.Authenticate(paramss);

                if(rpt.responsetoken == "ok")
                {
                    rpt = dalogin.Acceder(paramss);

                    if(rpt.response == "ok")
                    {
                        var token = TokenGenerator.GenerarTokenJwt(paramss.proyecto);
                        rpt.responsetoken = token;
                        return Ok(rpt);
                    }
                    else
                    {
                        return Ok(rpt);
                    }
                }
                else
                {
                    return Ok(rpt);
                }

            }
            catch (Exception ex)
            {
                Log.WriteLogError(ex.Message);
                throw ex;
            }
        }        
    }
}
