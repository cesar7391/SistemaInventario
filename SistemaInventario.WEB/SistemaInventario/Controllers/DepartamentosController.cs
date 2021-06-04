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
    public class DepartamentosController : Controller
    {
        private BUDepartamentos buDepartamentos;
        private modelList model;

        public DepartamentosController()
        {
            buDepartamentos = new BUDepartamentos();
            model = new modelList();
        }
        // GET: Departamentos
        public ActionResult Departamentos()
        {
            var session = Session.GetCurrentUser();

            if (session != null)
            {
                /* Si tienes acceso a productos tambien lo tienes a departamentos */
                if (session.productos == 1 | session.cargo == "superadmin")
                {
                    ENDepartamentos paramss = new ENDepartamentos();
                    paramss.rucempresa = session.ruc;
                    var token = session.responsetoken;

                    model.listaDepartamentos = buDepartamentos.listarDepartamentos(paramss, token);
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
        public ActionResult guardarDepartamento(ENDepartamentos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            var rpt = buDepartamentos.guardarDepartamento(paramss, token);
            return Json(new { dt = rpt });
        }

        [HttpPost]
        public ActionResult eliminarDepartamento(ENDepartamentos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            var rpt = buDepartamentos.eliminarDepartamento(paramss, token);
            return Json(new { dt = rpt });
        }


        [HttpPost]
        public ActionResult obtEditarDepartamento(ENDepartamentos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            ResponseDepartamentos rpt = new ResponseDepartamentos();

            string iddepartamento = paramss.datos;
            String[] strlist = iddepartamento.Split('|');
            var count = strlist.Count() - 1;

            if (count == 1)
            {
                rpt = buDepartamentos.obtEditarDepartamento(paramss, token);
                return Json(new { dt = rpt });
            }
            else
            {
                rpt.response = "Error";
                return Json(new { dt = rpt });
            }
        }


        [HttpPost]
        public ActionResult editarDepartamento(ENDepartamentos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            var rpt = buDepartamentos.editarDepartamento(paramss, token);
            return Json(new { dt = rpt });
        }
       
    }
}