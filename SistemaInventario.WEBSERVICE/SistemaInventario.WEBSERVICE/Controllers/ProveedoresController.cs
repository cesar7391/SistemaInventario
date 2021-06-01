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
    [RoutePrefix("api/Proveedores")]
    [Authorize]
    public class ProveedoresController : ApiController
    {
        private DAProveedores daProveedores;

        public ProveedoresController()
        {
            daProveedores = new DAProveedores();
        }


        [HttpPost]
        [Route("registrarProveedor")]
        public IHttpActionResult registrarProveedor(ENProveedores paramss)
        {
            try
            {
                var rpt = daProveedores.registrarProveedor(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        [HttpPost]
        [Route("listarProveedores")]
        public IHttpActionResult listarProveedores(ENProveedores paramss)
        {
            try
            {
                var rpt = daProveedores.listarProveedores(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpPost]
        [Route("desactivarProveedor")]
        public IHttpActionResult desactivarProveedor(ENProveedores paramss)
        {
            try
            {
                var rpt = daProveedores.desactivarProveedor(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpPost]
        [Route("activarProveedor")]
        public IHttpActionResult activarProveedor(ENProveedores paramss)
        {
            try
            {
                var rpt = daProveedores.activarProveedor(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpPost]
        [Route("eliminarProveedor")]
        public IHttpActionResult eliminarProveedor(ENProveedores paramss)
        {
            try
            {
                var rpt = daProveedores.eliminarProveedor(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        [Route("obteditarProveedor")]
        public IHttpActionResult obteditarProveedor(ENProveedores paramss)
        {
            try
            {
                var rpt = daProveedores.obteditarProveedor(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("editarProveedor")]
        public IHttpActionResult editarProveedor(ENProveedores paramss)
        {
            try
            {
                var rpt = daProveedores.editarProveedor(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }        
    }
}
