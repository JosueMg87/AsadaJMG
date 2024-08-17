using CapaEntidad;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CapaPresentacionAsada.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        public ActionResult Reestablecer()
        {
            return View();
        }

        public ActionResult CambiarClave()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Cliente cliente)
        {
            int resultado;
            string mensaje = string.Empty;

            ViewData["Nombre"] = string.IsNullOrEmpty(cliente.Nombre) ? "" : cliente.Nombre;
            ViewData["Direccion"] = string.IsNullOrEmpty(cliente.Direccion) ? "" : cliente.Direccion;
            ViewData["Correo"] = string.IsNullOrEmpty(cliente.Correo) ? "" : cliente.Correo;

            resultado = new CN_Cliente().Registrar(cliente, out mensaje);

            if (resultado > 0)
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Acceso");
            }
            else
            {
                ViewBag.Error = mensaje;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            Cliente oCliente = null;

            ViewBag.Error = null;
            return RedirectToAction("Index", "Tienda");
        }

       



    }
}