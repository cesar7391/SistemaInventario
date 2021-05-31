using SistemaInventario.BUSINESS;
using SistemaInventario.ENTITY.Encrypt;
using SistemaInventario.ENTITY.Parametros;
using SistemaInventario.Helpers;
using SistemaInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class EmpleadosController : Controller
    {
        private BUEmpleados buEmpleados;
        private modelList model;

        public EmpleadosController()
        {
            buEmpleados = new BUEmpleados();
            model = new modelList();
        }

        public ActionResult Empleados()
        {
            var session = Session.GetCurrentUser();

            if(session != null)
            {
                if (session.usuarios == 1 | session.cargo == "superadmin")
                {
                    ENEmpleados paramss = new ENEmpleados();
                    var token = session.responsetoken;
                    paramss.ruc = session.ruc;
                    paramss.slcargo = session.cargo;

                    model.listaEmpleados = buEmpleados.listaEmpleados(paramss, token);
                    model.listaCargos = buEmpleados.listaCargos(paramss, token);

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

            if(session.cargo == "superadmin")
            {
                var respuesta = "ok";
                return Json(new { dt = respuesta });
            }
            else
            {
                if (session.usuarios == 1)
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
        public ActionResult validarCantUsers()
        {
            var session = Session.GetCurrentUser();

            ENEmpleados paramss = new ENEmpleados();

            paramss.ruc = session.ruc;
            var token = session.responsetoken;

            var respuesta = buEmpleados.validarCantUsers(paramss, token);
            return Json(new { dt = respuesta });
        }

        [HttpPost]
        public ActionResult registrarUsuario(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();

            paramss.ruc = session.ruc;
            var token = session.responsetoken;
            var noEncrypt = paramss.password;

            var clave = Encrypt.GetSHA256(paramss.password);
            paramss.password = clave;

            var rpt = buEmpleados.registrarUsuario(paramss, token);

            if(rpt.response == "ok")
            {
                string url = string.Format("https://localhost:44300/Home/Index");
                string para = paramss.email;
                string asunto = "Datos de acceso al sistema | Sistema de Facturación e Inventario";
                string mensaje = "<b> SE REGISTRARON LOS ACCESOS PARA INGRESAR AL SISTEMA<b>" + "<br/><br/>" + "Estas son sus credenciales de acceso: " + "<br/><br/>" +
                    "Usuario: " + paramss.user + "<br/>" +
                    "Contraseña: " + noEncrypt + "<br/>" +
                    "Cargo: " + paramss.slcargo + "<br/><br/>" +
                    "Para poder acceder al sistema, <a href=\"" + url + "\"> ingrese aquí</a>" + "<br/><br/>" +
                    "Para obtener una licencia, escríbenos al correo cesar_7391@outlook.com";

                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("sthl.73915.8246@gmail.com");
                correo.To.Add(para);
                correo.Subject = asunto;
                correo.Body = mensaje;
                correo.IsBodyHtml = true;
                //Conecta al servidor para enviar el email
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); //Cambiar por su Smtphost
                string sCuentaCorreo = "sthl.73915.8246@gmail.com";
                string sPassword = "Inspiron5520";
                NetworkCredential credential = new NetworkCredential(sCuentaCorreo, sPassword);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = credential;
                smtpClient.Port = 25;
                smtpClient.EnableSsl = true;
                smtpClient.Send(correo);

                return Json(new { dt = rpt });
            }
            else
            {
                return Json(new { dt = rpt });
            }            
        }

        [HttpPost]
        public ActionResult activarEmpleado(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.ruc = session.ruc;

            var respuesta = buEmpleados.activarEmpleado(paramss, token);
            return Json(new { dt = respuesta });
        }

        //SE LLAMAN DESDE EL JS 
        [HttpPost]
        public ActionResult desactivarEmpleado(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.ruc = session.ruc;

            var respuesta = buEmpleados.desactivarEmpleado(paramss, token);
            return Json(new { dt = respuesta });
        }

        [HttpPost]
        public ActionResult eliminarEmpleado(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.ruc = session.ruc;

            var respuesta = buEmpleados.eliminarEmpleado(paramss, token);
            return Json(new { dt = respuesta });
        }

        [HttpPost]
        public ActionResult obteditarEmpleado(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.ruc = session.ruc;
            paramss.slcargo = session.cargo;

            var respuesta = buEmpleados.obteditarEmpleado(paramss, token);
            return Json(new { dt = respuesta });
        }

        [HttpPost]
        public ActionResult editarEmpleado(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();

            paramss.ruc = session.ruc;
            var token = session.responsetoken;
            var clave1 = paramss.password;

            if(paramss.password != "0")
            {
                var clave = Encrypt.GetSHA256(paramss.password);
                paramss.password = clave;
            }            

            var rpt = buEmpleados.editarEmpleado(paramss, token);

            if (rpt.response == "ok")
            {            
                return Json(new { dt = rpt });
            }
            else
            {
                return Json(new { dt = rpt });
            }
        }

    }
}
