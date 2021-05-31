using SistemaInventario.BUSINESS;
using SistemaInventario.ENTITY.Encrypt;
using SistemaInventario.ENTITY.Parametros;
using SistemaInventario.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class RegistroEmpresaController : Controller
    {
        private modelList model;
        private BUPais buPais;
        private BURegistroEmpresa buRegistroEmpresa;

        public RegistroEmpresaController()
        {
            model = new modelList();
            buPais = new BUPais();
            buRegistroEmpresa = new BURegistroEmpresa();
        }

        public ActionResult RegistroEmpresa(ENRegistroEmpresa paramss)
        {
            //Porque en la clase de CLIENTS se envía el token vacío
            string token = "";

            model.listPais = buPais.listarPaises(paramss,token);
            model.listMoneda = buPais.listarMoneda(paramss, token);
            model.listTImpuesto = buPais.listarTImpuesto(paramss, token);
            model.listPImpuesto = buPais.listarPImpuesto(paramss, token);

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult validarRegistro(ENRegistroEmpresa paramss)
        {
            string token = "";
            var respuesta = buRegistroEmpresa.validarRegistro(paramss,token);
            return Json(new { dt = respuesta });
        }

        [HttpPost]
        public ActionResult insertarEmpresa(HttpPostedFileBase file, string razonsocial, string ruc, string email,
                                             int idpais, int idmoneda, string direccion, int idimpuesto, int idporcentaje, 
                                             int vendeimpuesto, string username, string usuario, string contraseña)
        {

          

            try
            {
                var clave = Encrypt.GetSHA256(contraseña);
                var filename = "";

                if(file != null)
                {
                    string path = Server.MapPath("~/Content/img/img_empresas/" + ruc + "/");
                    string filePath = string.Empty;

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filePath = path + Path.GetFileName(file.FileName);
                    file.SaveAs(filePath);
                    filename = file.FileName;
                }

                var paramss = new ENRegistroEmpresa();
                paramss.razonSocial = razonsocial;
                paramss.ruc = ruc;
                paramss.email = email;
                paramss.idpais = idpais;
                paramss.idmoneda = idmoneda;
                paramss.direccion = direccion;
                paramss.idimpuesto = idimpuesto;
                paramss.idporcentaje = idporcentaje;
                paramss.vendeimpuesto = vendeimpuesto;
                paramss.username = username;
                paramss.usuario = usuario;
                paramss.contraseña = clave;
                paramss.cantUser = 1;
                paramss.cargo = "superadmin";
                paramss.filename = filename;
                paramss.proyecto = "FACTUR";

                string token = "";
                var respuesta = buRegistroEmpresa.insertarEmpresa(paramss, token);

                if(respuesta.response == "ok")
                {
                    respuesta = buRegistroEmpresa.insertarUserAdminEmpresa(paramss, token);

                    if(respuesta.response == "ok")
                    {
                        string url = string.Format("https://localhost:44300/ActivarCuenta/ActivarCuenta?ruc="+ruc);
                        string para = email;
                        string asunto = "Activación de cuenta | Sistema de Facturación e Inventario";
                        string mensaje = "<b> GRACIAS POR REGISTRARSE<b>" + "<br/><br/>" + "Estas son sus credenciales de acceso" + "<br/><br/>" +
                            "Usuario: " + usuario + "<br/>" +
                            "Contraseña: " + contraseña + "<br/>" +
                            "Cargo: " + paramss.cargo + "<br/><br/>" +
                            "Para poder acceder al sistema, debe activar la cuenta. <a href=\"" + url + "\">Actívela aquí</a>" + "<br/><br/>" +
                            "Recuerde, esto es un periodo de prueba por 15 días, para obtener una licencia, escríbenos al correo cesar_7391@outlook.com";

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
                        NetworkCredential credential = new NetworkCredential(sCuentaCorreo,sPassword);
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = credential;
                        smtpClient.Port = 25;
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(correo);

                        return Json(new { dt = respuesta });
                    }
                    else
                    {
                        return Json(new { dt = respuesta });
                    }
                }
                else
                {
                    return Json(new { dt = respuesta });
                }

                return Json(new { dt = respuesta });
            }
            catch(Exception e)
            {
                throw e;
            }

        }
    }
}
