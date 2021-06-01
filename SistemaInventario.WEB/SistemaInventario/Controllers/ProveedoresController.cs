using SistemaInventario.BUSINESS;
using SistemaInventario.ENTITY.Parametros;
using SistemaInventario.Helpers;
using SistemaInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class ProveedoresController : Controller
    {
        private BUProveedores buProveedores;
        private modelList model;
        public ProveedoresController()
        {
            buProveedores = new BUProveedores();
            model = new modelList();
        }

        // GET: Proveedores
        public ActionResult Proveedores(ENProveedores paramss)
        {
            var session = Session.GetCurrentUser();

            if (session != null)
            {
                //VERIFICA QUE TENGA ACCESO, SI NO ES SUPERADMIN REGRESA A PANEL
                if (session.proveedor == 1 | session.cargo == "superadmin")
                {
                    var token = session.responsetoken;
                    paramss.rucempresa = session.ruc;

                    model.listaProveedores = buProveedores.listarProveedores(paramss, token);
                    //Se debe regresar el modelo
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
                var respuesta = "ok";
                return Json(new { dt = respuesta });
            }
            else
            {
                if (session.proveedor == 1)
                {
                    var respuesta = "ok";
                    return Json(new { dt = respuesta });
                }
                else
                {
                    var respuesta = "error";
                    return Json(new { dt = respuesta });
                }
            }
        }

        [HttpPost]
        public ActionResult registrarProveedor(ENProveedores paramss)
        {
            var user = Session.GetCurrentUser();
            var token = user.responsetoken;
            paramss.rucempresa = user.ruc;

            var rpt = buProveedores.registrarProveedor(paramss,token);

            return Json(new { dt = rpt });
        }

        [HttpPost]
        public ActionResult activarProveedor(ENProveedores paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            var rpt = buProveedores.activarProveedor(paramss, token);
            return Json(new { dt = rpt });
        }

        [HttpPost]
        public ActionResult desactivarProveedor(ENProveedores paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            var rpt = buProveedores.desactivarProveedor(paramss, token);
            return Json(new { dt = rpt });
        }

        
        [HttpPost]
        public ActionResult eliminarProveedor(ENProveedores paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            var rpt = buProveedores.eliminarProveedor(paramss, token);
            return Json(new { dt = rpt });
        }

        
        [HttpPost]
        public ActionResult obteditarProveedor(ENProveedores paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;

            var rpt = buProveedores.obteditarProveedor(paramss, token);
            return Json(new { dt = rpt });
        }

        [HttpPost]
        public ActionResult editarProveedor(ENProveedores paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            var rpt = buProveedores.editarProveedor(paramss, token);
            return Json(new { dt = rpt });
        }       

    }
}
