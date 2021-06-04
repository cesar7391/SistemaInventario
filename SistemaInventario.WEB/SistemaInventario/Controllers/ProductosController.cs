using SistemaInventario.BUSINESS;
using SistemaInventario.ENTITY.Parametros;
using SistemaInventario.ENTITY.Response;
using SistemaInventario.Helpers;
using SistemaInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class ProductosController : Controller
    {
        private BUProductos buProductos;
        private modelList model;
        // GET: Productos

        public ProductosController()
        {
            buProductos = new BUProductos();
            model = new modelList();
        }

        public ActionResult Productos()
        {
            var session = Session.GetCurrentUser();

            if (session != null)
            {

                if (session.productos == 1 | session.cargo == "superadmin")
                {
                    ENDepartamentos paramssDepartamento = new ENDepartamentos();
                    ENProductos paramssProducto = new ENProductos();
                    //Debe enviarse el token para entrar a la API
                    var token = session.responsetoken;
                    paramssProducto.rucempresa = session.ruc;

                    model.listaDepartamentos = buProductos.listarDepartamentos(paramssDepartamento, token);
                    model.listaProductos = buProductos.listarProductos(paramssProducto, token);
                    model.tipomoneda = buProductos.tipoMoneda(paramssProducto, token);

                    return View(model);
                }
                else
                {
                    return RedirectToAction("Panel", "Panel");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult validarAccesoModulo()
        {
            var session = Session.GetCurrentUser();

            if (session.cargo == "superadmin")
            {
                var rpt = "ok";
                return Json(new { dt = rpt });
            }
            else
            {
                if (session.productos == 1)
                {
                    var rpt = "ok";
                    return Json(new { dt = rpt });
                }
                else
                {
                    var rpt = "error";
                    return Json(new { dt = rpt });
                }
            }
        }

        [HttpPost]
        public ActionResult calcularPventaSinImpuestos(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;


            var rpt = buProductos.calcularPventaSinImpuestos(paramss, token);
            return Json(new { dt = rpt });
        }

        
        [HttpPost]
        public ActionResult calculoPrecios(ENProductos paramss)
        {
            //Es un método directo que trabaja con los valores obtenidos
            if (paramss.pmayoreo > paramss.pventa)
            {
                var rpt = "error";
                return Json(new { dt = rpt });
            }
            else
            {
                var rpt = "ok";
                return Json(new { dt = rpt });
            }

        }        

        [HttpPost]
        public ActionResult guardarProducto(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            var rpt = buProductos.guardarProducto(paramss, token);
            return Json(new { dt = rpt });
        }
        
        [HttpPost]
        public ActionResult buscarProducto(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            model.listaBuscarP = buProductos.buscarProducto(paramss, token);
            return Json(new { dt = model.listaBuscarP, total = 10 });
        }
        
        [HttpPost]
        public ActionResult buscarProductoDepartamento(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            model.listaBuscarPD = buProductos.buscarProductoDepartamento(paramss, token);
            return Json(new { dt = model.listaBuscarPD, total = model.listaBuscarPD.Count() });
        }
                
        [HttpPost]
        public ActionResult eliminarProducto(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            var rpt = buProductos.eliminarProducto(paramss, token);
            return Json(new { dt = rpt });
        }
        
        [HttpPost]
        public ActionResult obtEditarProducto(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            ResponseProductos rpt = new ResponseProductos();

            string idproductos = paramss.datos;
            String[] strlist = idproductos.Split('|');
            var count = strlist.Count() - 1;

            if (count == 1)
            {
                rpt = buProductos.obtEditarProducto(paramss, token);
                return Json(new { dt = rpt });
            }
            else
            {
                rpt.response = "Error";
                return Json(new { dt = rpt });
            }
        }

        
        [HttpPost]
        public ActionResult editarProducto(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            var rpt = buProductos.editarProducto(paramss, token);
            return Json(new { dt = rpt });
        }


        /* ES DE TIPO JSONRESULT, OBTIENE LA LISTA DE PRODUCTOS*/
        [HttpPost]
        public JsonResult obtlistaProducto(string letra)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;

            ENProductos paramss = new ENProductos();
            paramss.rucempresa = session.ruc;
            paramss.letra = letra;
            return Json(buProductos.obtlistaProducto(paramss, token), JsonRequestBehavior.AllowGet);
        }

        /*
        [HttpPost]
        public JsonResult obtlistaProducto_cod(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;
            paramss.letra = paramss.codbarra;

            var rpt = buproduc.obtlistaProducto(paramss, token);
            return Json(new { dt = rpt });


        }
        */
    }
}