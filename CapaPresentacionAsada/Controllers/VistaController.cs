using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocios;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace CapaPresentacionAsada.Controllers
{
    public class VistaController : Controller
    {
        // GET: Vista
        public ActionResult Index()
        {
            CN_Informacion cnInformacion = new CN_Informacion();

            Informacion oInformacion5 = cnInformacion.ObtenerPorId(5);
            Informacion oInformacion7 = cnInformacion.ObtenerPorId(7);
            Informacion oInformacion8 = cnInformacion.ObtenerPorId(8);
            Informacion oInformacion9 = cnInformacion.ObtenerPorId(9);
            Informacion oInformacion10 = cnInformacion.ObtenerPorId(10);
            Informacion oInformacion11 = cnInformacion.ObtenerPorId(11);

            if (oInformacion5 == null)
            {
                ViewBag.Nombre5 = "Nombre de Asada no disponible";
                ViewBag.Descripcion5 = "Nombre de Asada no disponible";
            }
            else
            {
                ViewBag.Nombre5 = oInformacion5.Nombre;
                ViewBag.Descripcion5 = oInformacion5.Descripcion;
            }
            if (oInformacion7 == null)
            {
                ViewBag.Nombre7 = "Visión no disponible";
                ViewBag.Descripcion7 = "Visión no disponible";
            }
            else
            {
                ViewBag.Nombre7 = oInformacion7.Nombre;
                ViewBag.Descripcion7 = oInformacion7.Descripcion;
            }
            if (oInformacion8 == null)
            {
                ViewBag.Nombre8 = "Misión no disponible";
                ViewBag.Descripcion8 = "Misión no disponible";
            }
            else
            {
                ViewBag.Nombre8 = oInformacion8.Nombre;
                ViewBag.Descripcion8 = oInformacion8.Descripcion;
            
            }
            if (oInformacion9 == null)
            {
                ViewBag.Nombre9 = "Valores no disponible";
                ViewBag.Descripcion9 = "Valores no disponible";
            }
            else
            {
                ViewBag.Nombre9 = oInformacion9.Nombre;
                ViewBag.Descripcion9 = oInformacion9.Descripcion;
            }
            if (oInformacion10 == null)
            {
                ViewBag.Nombre10 = "Bienvenida de Asada en Inicio no disponible";
                ViewBag.Descripcion10 = "Bienvenida de Asada en Inicio no disponible";
            }
            else
            {
                ViewBag.Nombre10 = oInformacion10.Nombre;
                ViewBag.Descripcion10 = oInformacion10.Descripcion;
            }
            if (oInformacion11 == null)
            {
                ViewBag.Nombre11 = "Sobre la asada no disponible";
                ViewBag.Descripcion11 = "Sobre la asada no disponible";
            }
            else
            {
                ViewBag.Nombre11 = oInformacion11.Nombre;
                ViewBag.Descripcion11 = oInformacion11.Descripcion;
            }
            

            return View();
        }

        public ActionResult Reportes()
        {
            CN_Informacion cnInformacion = new CN_Informacion();

            Informacion oInformacion5 = cnInformacion.ObtenerPorId(5);
            if (oInformacion5 == null)
            {
                ViewBag.Nombre5 = "Nombre de Asada no disponible";
                ViewBag.Descripcion5 = "Nombre de Asada no disponible";
            }
            else
            {
                ViewBag.Nombre5 = oInformacion5.Nombre;
                ViewBag.Descripcion5 = oInformacion5.Descripcion;
            }
            return View();
        }
        
        public ActionResult Anuncio()
        {
            CN_Informacion cnInformacion = new CN_Informacion();

            Informacion oInformacion5 = cnInformacion.ObtenerPorId(5);
            if (oInformacion5 == null)
            {
                ViewBag.Nombre5 = "Nombre de Asada no disponible";
                ViewBag.Descripcion5 = "Nombre de Asada no disponible";
            }
            else
            {
                ViewBag.Nombre5 = oInformacion5.Nombre;
                ViewBag.Descripcion5 = oInformacion5.Descripcion;
            }
            return View();
        }

        public ActionResult Contacto()
        {
            CN_Informacion cnInformacion = new CN_Informacion();

            Informacion oInformacion5 = cnInformacion.ObtenerPorId(5);
            Informacion oInformacion7 = cnInformacion.ObtenerPorId(7);
            Informacion oInformacion8 = cnInformacion.ObtenerPorId(8);
            Informacion oInformacion9 = cnInformacion.ObtenerPorId(9);
            Informacion oInformacion12 = cnInformacion.ObtenerPorId(12);
            Informacion oInformacion13 = cnInformacion.ObtenerPorId(13);
            Informacion oInformacion14 = cnInformacion.ObtenerPorId(14);
            Informacion oInformacion15 = cnInformacion.ObtenerPorId(1011);
            Informacion oInformacion16 = cnInformacion.ObtenerPorId(1012);

            if (oInformacion5 == null)
            {
                ViewBag.Nombre5 = "Nombre de Asada no disponible";
                ViewBag.Descripcion5 = "Nombre de Asada no disponible";
            }
            else
            {
                ViewBag.Nombre5 = oInformacion5.Nombre;
                ViewBag.Descripcion5 = oInformacion5.Descripcion;
            }
            if (oInformacion7 == null)
            {
                ViewBag.Nombre7 = "Visión no disponible";
                ViewBag.Descripcion7 = "Visión no disponible";
            }
            else
            {
                ViewBag.Nombre7 = oInformacion7.Nombre;
                ViewBag.Descripcion7 = oInformacion7.Descripcion;
            }
            if (oInformacion8 == null)
            {
                ViewBag.Nombre8 = "Misión no disponible";
                ViewBag.Descripcion8 = "Misión no disponible";
            }
            else
            {
                ViewBag.Nombre8 = oInformacion8.Nombre;
                ViewBag.Descripcion8 = oInformacion8.Descripcion;

            }
            if (oInformacion9 == null)
            {
                ViewBag.Nombre9 = "Valores no disponible";
                ViewBag.Descripcion9 = "Valores no disponible";
            }
            else
            {
                ViewBag.Nombre9 = oInformacion9.Nombre;
                ViewBag.Descripcion9 = oInformacion9.Descripcion;
            }
            if (oInformacion12 == null)
            {
                ViewBag.Nombre12 = "Facebook no disponible";
                ViewBag.Descripcion12 = "Facebook no disponible";
            }
            else
            {
                ViewBag.Nombre12 = oInformacion12.Nombre;
                ViewBag.Descripcion12 = oInformacion12.Descripcion;
            }
            if (oInformacion13 == null)
            {
                ViewBag.Nombre13 = "Teléfono no disponible";
                ViewBag.Descripcion13 = "Teléfono no disponible";
            }
            else
            {
                ViewBag.Nombre13 = oInformacion13.Nombre;
                ViewBag.Descripcion13 = oInformacion13.Descripcion;
            }
            if (oInformacion14 == null)
            {
                ViewBag.Nombre14 = "Correo Electrónico no disponible";
                ViewBag.Descripcion14 = "Correo Electrónico no disponible";
            }
            else
            {
                ViewBag.Nombre14 = oInformacion14.Nombre;
                ViewBag.Descripcion14 = oInformacion14.Descripcion;
            }
            if (oInformacion15 == null)
            {
                ViewBag.Nombre15 = "Dirección no disponible";
                ViewBag.Descripcion15 = "Dirección no disponible";
            }
            else
            {
                ViewBag.Nombre15 = oInformacion15.Nombre;
                ViewBag.Descripcion15 = oInformacion15.Descripcion;
            }
            if (oInformacion16 == null)
            {
                ViewBag.Nombre16 = "WhatsApp no disponible";
                ViewBag.Descripcion16 = "WhatsApp no disponible";
            }
            else
            {
                ViewBag.Nombre16 = oInformacion16.Nombre;
                ViewBag.Descripcion16 = oInformacion16.Descripcion;
            }

            return View();
        }
        
        public ActionResult Historial()
        {
            CN_Informacion cnInformacion = new CN_Informacion();

            Informacion oInformacion5 = cnInformacion.ObtenerPorId(5);
            if (oInformacion5 == null)
            {
                ViewBag.Nombre5 = "Nombre de Asada no disponible";
                ViewBag.Descripcion5 = "Nombre de Asada no disponible";
            }
            else
            {
                ViewBag.Nombre5 = oInformacion5.Nombre;
                ViewBag.Descripcion5 = oInformacion5.Descripcion;
            }
            return View();
        }

        //REPORTES
        #region
        public ActionResult DetalleReportes(int idReportes = 0)
        {
            Reportes oReportes = new Reportes();
            bool conversion;

            oReportes = new CN_Reportes().Listar().Where(p => p.IdReportes == idReportes).FirstOrDefault();


            if (oReportes != null)
            {
                oReportes.Base64 = CN_Recursos.ConvertirBase64(Path.Combine(oReportes.RutaImagen, oReportes.NombreImagen), out conversion);
                oReportes.Extension = Path.GetExtension(oReportes.NombreImagen);
            }
            return View(oReportes);
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

        [HttpPost]
        public JsonResult ListarReportes()
        {
            List<Reportes> lista = new List<Reportes>();
            bool conversion;
            lista = new CN_Reportes().Listar().Select(p => new Reportes()
            {
                IdReportes = p.IdReportes,
                Descripcion = p.Descripcion,
                Titulo = p.Titulo,
                RutaImagen = p.RutaImagen,
                Base64 = CN_Recursos.ConvertirBase64(Path.Combine(p.RutaImagen, p.NombreImagen), out conversion),
                Extension = Path.GetExtension(p.NombreImagen),
            }).ToList();

            var jsonresult = Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            jsonresult.MaxJsonLength = int.MaxValue;
            return jsonresult;
        }
        #endregion

        //HISTORIAL
        #region
        public ActionResult DetalleHistorial(int idHistorial = 0)
        {
            Historial oHistorial = new Historial();
            bool conversion;
            oHistorial = new CN_Historial().Listar().Where(p => p.IdHistorial == idHistorial).FirstOrDefault();

            if (oHistorial != null)
            {
                oHistorial.Base64 = CN_Recursos.ConvertirBase64(Path.Combine(oHistorial.RutaImagen, oHistorial.NombreImagen), out conversion);
                oHistorial.Extension = Path.GetExtension(oHistorial.NombreImagen);
            }
            return View(oHistorial);
        }

        [HttpPost]
        public JsonResult ListarHistorial()
        {
            List<Historial> lista = new List<Historial>();
            bool conversion;
            lista = new CN_Historial().Listar().Select(p => new Historial()
            {
                IdHistorial = p.IdHistorial,
                Descripcion = p.Descripcion,
                Titulo = p.Titulo,
                RutaImagen = p.RutaImagen,
                Base64 = CN_Recursos.ConvertirBase64(Path.Combine(p.RutaImagen, p.NombreImagen), out conversion),
                Extension = Path.GetExtension(p.NombreImagen),
            }).ToList();

            var jsonresult = Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            jsonresult.MaxJsonLength = int.MaxValue;
            return jsonresult;
        }
        #endregion

        //ANUNCIOS
        #region
        public ActionResult DetalleAnuncio(int idAnuncio = 0)
        {
            Anuncio oAnuncio = new Anuncio();
            bool conversion;

            oAnuncio = new CN_Anuncio().Listar().Where(p => p.IdAnuncio == idAnuncio).FirstOrDefault();


            if (oAnuncio != null)
            {
                oAnuncio.Base64 = CN_Recursos.ConvertirBase64(Path.Combine(oAnuncio.RutaImagen, oAnuncio.NombreImagen), out conversion);
                oAnuncio.Extension = Path.GetExtension(oAnuncio.NombreImagen);
            }
            return View(oAnuncio);
        }

        [HttpPost]
        public JsonResult ListarAnuncio()
        {
            List<Anuncio> lista = new List<Anuncio>();
            bool conversion;
            lista = new CN_Anuncio().Listar().Select(p => new Anuncio()
            {
                IdAnuncio = p.IdAnuncio,
                Descripcion = p.Descripcion,
                Titulo = p.Titulo,
                RutaImagen = p.RutaImagen,
                Base64 = CN_Recursos.ConvertirBase64(Path.Combine(p.RutaImagen, p.NombreImagen), out conversion),
                Extension = Path.GetExtension(p.NombreImagen),
            }).ToList();

            var jsonresult = Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            jsonresult.MaxJsonLength = int.MaxValue;
            return jsonresult;
        }
        #endregion



    }
}