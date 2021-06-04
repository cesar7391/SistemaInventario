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
    [RoutePrefix("api/Productos")]
    [Authorize]
    public class ProductosController : ApiController
    {

        private DAProductos daProductos;

        public ProductosController()
        {
            daProductos = new DAProductos();
        }


        [HttpPost]
        [Route("calcularPventaSinImpuestos")]
        public IHttpActionResult calcularPventaSinImpuestos(ENProductos paramss)
        {
            try
            {
                var rpt = daProductos.calcularPventaSinImpuestos(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        

        
        [HttpPost]
        [Route("listarDepartamentos")]
        public IHttpActionResult listarDepartamentos(ENDepartamentos paramss)
        {
            try
            {
                var rpt = daProductos.listarDepartamentos(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        [HttpPost]
        [Route("guardarProducto")]
        public IHttpActionResult guardarProducto(ENProductos paramss)
        {
            try
            {
                var rpt = daProductos.guardarProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        [Route("listarProductos")]
        public IHttpActionResult listarProductos(ENProductos paramss)
        {
            try
            {
                var rpt = daProductos.listarProductos(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpPost]
        [Route("buscarProducto")]
        public IHttpActionResult buscarProducto(ENProductos paramss)
        {
            try
            {
                var rpt = daProductos.buscarProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        [Route("buscarProductoDepartamento")]
        public IHttpActionResult buscarProductoDepartamento(ENProductos paramss)
        {
            try
            {
                var rpt = daProductos.buscarProductoDepartamento(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        [Route("eliminarProducto")]
        public IHttpActionResult eliminarProducto(ENProductos paramss)
        {
            try
            {
                var rpt = daProductos.eliminarProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("tipoMoneda")]
        public IHttpActionResult tipoMoneda(ENProductos paramss)
        {
            try
            {
                var rpt = daProductos.tipoMoneda(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        [Route("obtEditarProducto")]
        public IHttpActionResult obtEditarProducto(ENProductos paramss)
        {
            try
            {
                var rpt = daProductos.obtEditarProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        [Route("editarProducto")]
        public IHttpActionResult editarProducto(ENProductos paramss)
        {
            try
            {
                var rpt = daProductos.editarProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("obtlistaProducto")]
        public IHttpActionResult obtlistaProducto(ENProductos paramss)
        {
            try
            {
                var rpt = daProductos.obtlistaProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }       

    }
}
