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

        /*
        [HttpPost]
        [Route("listarProductos")]
        public IHttpActionResult listarProductos(ENProductos paramss)
        {
            try
            {
                var rpt = daproduc.listarProductos(paramss);
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
                var rpt = daproduc.buscarProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Route("buscarProductodepart")]
        public IHttpActionResult buscarProductodepart(ENProductos paramss)
        {
            try
            {
                var rpt = daproduc.buscarProductodepart(paramss);
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
                var rpt = daproduc.eliminarProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [HttpPost]
        [Route("tmoneda")]
        public IHttpActionResult tmoneda(ENProductos paramss)
        {
            try
            {
                var rpt = daproduc.tmoneda(paramss);
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
                var rpt = daproduc.obtEditarProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Route("editarProduct")]
        public IHttpActionResult editarProduct(ENProductos paramss)
        {
            try
            {
                var rpt = daproduc.editarProduct(paramss);
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
                var rpt = daproduc.obtlistaProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        */


    }
}
