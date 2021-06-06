using SistemaInventario.DATOS;
using SistemaInventario.ENTITY.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemaInventario.WEBSERVICE.Controllers
{
    [RoutePrefix("api/Inventarios")]
    [Authorize]
    public class InventariosController : ApiController
    {

        private DAInventario daInventario;

        public InventariosController()
        {
            daInventario = new DAInventario();
        }

        [HttpPost]
        [Route("agregarInventario")]
        public IHttpActionResult agregarInventario(ENInventario paramss)
        {
            try
            {
                var rpt = daInventario.agregarInventario(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
