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
    [RoutePrefix("api/Promociones")]
    [Authorize]
    public class PromocionesController : ApiController
    {
        private DAPromociones daPromociones;

        public PromocionesController()
        {
            daPromociones = new DAPromociones();
        }


        [HttpPost]
        [Route("guardarPromocion")]
        public IHttpActionResult guardarPromocion(ENPromociones paramss)
        {
            try
            {
                var rpt = daPromociones.guardarPromocion(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("listarPromociones")]
        public IHttpActionResult listarPromociones(ENPromociones paramss)
        {
            try
            {
                var rpt = daPromociones.listarPromociones(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("eliminarPromociones")]
        public IHttpActionResult eliminarPromociones(ENPromociones paramss)
        {
            try
            {
                var rpt = daPromociones.eliminarPromociones(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("obtEditarPromo")]
        public IHttpActionResult obtEditarPromo(ENPromociones paramss)
        {
            try
            {
                var rpt = daPromociones.obtEditarPromo(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("editarPromocion")]
        public IHttpActionResult editarPromocion(ENPromociones paramss)
        {
            try
            {
                var rpt = daPromociones.editarPromocion(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
