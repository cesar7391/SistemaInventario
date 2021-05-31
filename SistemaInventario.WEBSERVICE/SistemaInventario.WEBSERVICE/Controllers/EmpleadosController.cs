using SistemaInventario.DATOS;
using SistemaInventario.ENTITY.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//Controlador API vacío... MVP2
namespace SistemaInventario.WEBSERVICE.Controllers
{
    [RoutePrefix("api/Empleados")]
    [Authorize]
    public class EmpleadosController : ApiController
    {
        private DAEmpleados daEmpleados;

        public EmpleadosController()
        {
            daEmpleados = new DAEmpleados();
        }

        //Para enviar tokens se usa authorize
        [HttpPost]      
        [Route("validarCantUsers")]
        public IHttpActionResult validarCantUsers(ENEmpleados paramss)
        {
            try
            {
                var rpt = daEmpleados.validarCantUsers(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("registarUsuario")]
        public IHttpActionResult registarUsuario(ENEmpleados paramss)
        {
            try
            {
                var rpt = daEmpleados.registarUsuario(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("listaEmpleados")]
        public IHttpActionResult listaEmpleados(ENEmpleados paramss)
        {
            try
            {
                var rpt = daEmpleados.listaEmpleados(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("activarEmpleado")]
        public IHttpActionResult activarEmpleado(ENEmpleados paramss)
        {
            try
            {
                var rpt = daEmpleados.activarEmpleado(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SE LLAMA DESDE LA APLICACÍÓN BU, 3 REFERENCIAS
        [HttpPost]
        [Route("desactivarEmpleado")]
        public IHttpActionResult desactivarEmpleado(ENEmpleados paramss)
        {
            try
            {
                var rpt = daEmpleados.desactivarEmpleado(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("eliminarEmpleado")]
        public IHttpActionResult eliminarEmpleado(ENEmpleados paramss)
        {
            try
            {
                var rpt = daEmpleados.eliminarEmpleado(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("listaCargos")]
        public IHttpActionResult listaCargos(ENEmpleados paramss)
        {
            try
            {
                var rpt = daEmpleados.listaCargos(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        [Route("obteditarEmpleado")]
        public IHttpActionResult obteditarEmpleado(ENEmpleados paramss)
        {
            try
            {
                var rpt = daEmpleados.obteditarEmpleado(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("editarEmpleado")]
        public IHttpActionResult editarEmpleado(ENEmpleados paramss)
        {
            try
            {
                var rpt = daEmpleados.editarEmpleado(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
