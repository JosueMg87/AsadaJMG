using CapaEntidad;
using CapaNegocios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace CapaPresentacionAdmin.Controllers
{
    [Authorize]
    public class MantenedorController : Controller
    {
        public ActionResult Historial()
        {
            return View();
        }
        
        public ActionResult Anuncio()
        {
            return View();
        }
        
        public ActionResult Informacion()
        {
            return View();
        }
        
        public ActionResult Reportes()
        {
            return View();
        }

        //HISTORIAL
        #region HISTORIAL
        [HttpGet]
        public JsonResult ListarHistorial()
        {
            List<Historial> oLista = new List<Historial>();

            oLista = new CN_Historial().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarHistorial(string objeto, HttpPostedFileBase archivoImagen)
        {
            string mensaje = string.Empty;
            bool operacion_exitosa = true;
            bool guardar_imagen_exito = true;

            Historial oHistorial = JsonConvert.DeserializeObject<Historial>(objeto);

            if (oHistorial.IdHistorial == 0)
            {
                int idHistorialGenerado = new CN_Historial().Registrar(oHistorial, out mensaje);
                if (idHistorialGenerado != 0)
                {
                    oHistorial.IdHistorial = idHistorialGenerado;
                }
                else
                {
                    operacion_exitosa = false;
                }
            }
            else
            {
                operacion_exitosa = new CN_Historial().Editar(oHistorial, out mensaje);
            }

            if (!operacion_exitosa)  // Si la operación falló, retorna el mensaje de error
            {
                return Json(new { operacion_exitosa = false, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
            }

            if (operacion_exitosa && archivoImagen != null)
            {
                string ruta_guardar = ConfigurationManager.AppSettings["ServidorFotos"];
                string extension = Path.GetExtension(archivoImagen.FileName);
                string nombre_Imagen = string.Concat(oHistorial.IdHistorial.ToString(), extension);

                try
                {
                    archivoImagen.SaveAs(Path.Combine(ruta_guardar, nombre_Imagen));
                }
                catch (Exception ex)
                {
                    mensaje = "Hubo un problema al guardar la imagen.";
                    guardar_imagen_exito = false;
                }

                if (guardar_imagen_exito)
                {
                    oHistorial.RutaImagen = Path.Combine(ruta_guardar, nombre_Imagen); // Asigna la ruta completa
                    oHistorial.NombreImagen = nombre_Imagen;
                    bool respuesta = new CN_Historial().GuardarDatosImagen(oHistorial, out mensaje);
                }
                else
                {
                    mensaje = "Se guardó el Historial pero hubo problemas con la imagen.";
                }
            }

            return Json(new { operacion_exitosa = true, idGenerado = oHistorial.IdHistorial, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult EliminarHistorial(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Historial().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //ANUNCIO
        #region ANUNCIO
        [HttpGet]
        public JsonResult ListarAnuncio()
        {
            List<Anuncio> oLista = new List<Anuncio>();

            oLista = new CN_Anuncio().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarAnuncio(string objeto, HttpPostedFileBase archivoImagen)
        {
            string mensaje = string.Empty;
            bool operacion_exitosa = true;
            bool guardar_imagen_exito = true;

            Anuncio oAnuncio = new Anuncio();
            oAnuncio = JsonConvert.DeserializeObject<Anuncio>(objeto);


            if (oAnuncio.IdAnuncio == 0)
            {
                int idAnuncioGenerado = new CN_Anuncio().Registrar(oAnuncio, out mensaje);
                if (idAnuncioGenerado != 0)
                {
                    oAnuncio.IdAnuncio = idAnuncioGenerado;
                }
                else
                {
                    operacion_exitosa = false;
                }
            }
            else
            {
                operacion_exitosa = new CN_Anuncio().Editar(oAnuncio, out mensaje);
            }
            if (operacion_exitosa)
            {
                if (archivoImagen != null)
                {
                    string ruta_guardar = ConfigurationManager.AppSettings["ServidorFotos"];
                    string extension = Path.GetExtension(archivoImagen.FileName);
                    string nombre_Imagen = string.Concat(oAnuncio.IdAnuncio.ToString(), extension);

                    try
                    {
                        archivoImagen.SaveAs(Path.Combine(ruta_guardar, nombre_Imagen));
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        guardar_imagen_exito = false;
                    }

                    if (guardar_imagen_exito)
                    {
                        oAnuncio.RutaImagen = ruta_guardar;
                        oAnuncio.NombreImagen = nombre_Imagen;
                        bool respuesta = new CN_Anuncio().GuardarDatosImagen(oAnuncio, out mensaje);
                    }
                    else
                    {
                        mensaje = "Se guardo el Anuncio pero hubo problemas con la imagen";
                    }
                }
            }
            return Json(new { operacion_exitosa = operacion_exitosa, idGenerado = oAnuncio.IdAnuncio, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarAnuncio(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Anuncio().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //INFORMACION
        #region INFORMACION
        [HttpGet]
        public JsonResult ListarInformacion()
        {
            List<Informacion> oLista = new List<Informacion>();

            oLista = new CN_Informacion().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarInformacion(Informacion objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdInformacion == 0)
            {
                resultado = new CN_Informacion().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Informacion().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarInformacion(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Informacion().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //REPORTES
        #region REPORTES
        [HttpGet]
        public JsonResult ListarReportes()
        {
            List<Reportes> oLista = new List<Reportes>();

            oLista = new CN_Reportes().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarReportes(string objeto, HttpPostedFileBase archivoImagen)
        {
            string mensaje = string.Empty;
            bool operacion_exitosa = true;
            bool guardar_imagen_exito = true;

            Reportes oReportes = new Reportes();
            oReportes = JsonConvert.DeserializeObject<Reportes>(objeto);


            if (oReportes.IdReportes == 0)
            {
                int idReportesGenerado = new CN_Reportes().Registrar(oReportes, out mensaje);
                if (idReportesGenerado != 0)
                {
                    oReportes.IdReportes = idReportesGenerado;
                }
                else
                {
                    operacion_exitosa = false;
                }
            }
            else
            {
                operacion_exitosa = new CN_Reportes().Editar(oReportes, out mensaje);
            }
            if (operacion_exitosa)
            {
                if (archivoImagen != null)
                {
                    string ruta_guardar = ConfigurationManager.AppSettings["ServidorFotos"];
                    string extension = Path.GetExtension(archivoImagen.FileName);
                    string nombre_Imagen = string.Concat(oReportes.IdReportes.ToString(), extension);

                    try
                    {
                        archivoImagen.SaveAs(Path.Combine(ruta_guardar, nombre_Imagen));
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        guardar_imagen_exito = false;
                    }

                    if (guardar_imagen_exito)
                    {
                        oReportes.RutaImagen = ruta_guardar;
                        oReportes.NombreImagen = nombre_Imagen;
                        bool respuesta = new CN_Reportes().GuardarDatosImagen(oReportes, out mensaje);
                    }
                    else
                    {
                        mensaje = "Se guardo el Reporte pero hubo problemas con la imagen";
                    }
                }
            }
            return Json(new { operacion_exitosa = operacion_exitosa, idGenerado = oReportes.IdReportes, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarReportes(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Reportes().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion







    }
}