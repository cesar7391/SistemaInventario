using SistemaInventario.BUSINESS;
using SistemaInventario.ENTITY.Parametros;
using SistemaInventario.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class InventariosController : Controller
    {
        private BUInventario buInventario;

        public InventariosController()
        {
            buInventario = new BUInventario();
        }

        // Se llama al nombre de la vista...
        public ActionResult Inventarios()
        {
            var session = Session.GetCurrentUser();

            if (session != null)
            {
                /* Si tienes acceso a productos tambien lo tienes a departamentos */
                if (session.inventario == 1 | session.cargo == "superadmin")
                {
                    return View();
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

        //Validación del ACCESO AL MÓDULO
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
                if (session.inventario == 1)
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
        public ActionResult agregarInventario(ENInventario paramss)
        {
            var session = Session.GetCurrentUser();

            paramss.rucempresa = session.ruc;
            var token = session.responsetoken;

            var rpt = buInventario.agregarInventario(paramss, token);

            return Json(new { dt = rpt });
        }

    }
}