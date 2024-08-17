using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CapaEntidad;
using CapaNegocios;
using ClosedXML.Excel;
using OfficeOpenXml;

namespace CapaPresentacionAdmin.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }
        
        public ActionResult Clientes()
        {
            return View();
        }
        //CLIENTES
        [HttpGet]
        public JsonResult ListarClientes()
        {
            try
            {
                List<Cliente> oLista = new CN_Cliente().Listar();
                return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Maneja el error aquí
                return Json(new { data = new List<Cliente>(), error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public FileResult ExportarClientes()
        {
            // Obtener los datos de la base de datos
            List<Cliente> oLista = new List<Cliente>();

            oLista = new CN_Cliente().Listar(); ; // Implementa esta función para obtener los clientes

            // Crear un DataTable y agregar las columnas
            DataTable dt = new DataTable();
            dt.Columns.Add("Paja", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("Direccion", typeof(string));
            dt.Columns.Add("Correo", typeof(string));
            dt.Columns.Add("Cedula", typeof(string));
            dt.Columns.Add("Sector", typeof(string));

            // Agregar los datos al DataTable
            foreach (var cliente in oLista)
            {
                dt.Rows.Add(cliente.Paja, cliente.Nombre, cliente.Telefono, cliente.Direccion, cliente.Correo, cliente.Cedula, cliente.Sector);
            }

            // Crear el archivo Excel
            using (var workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(dt, "Clientes");
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var fileName = "Clientes_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }

        [HttpPost]
        public ActionResult ImportarClientes(HttpPostedFileBase archivo)
        {
            string mensaje = string.Empty;
            if (archivo != null && archivo.ContentLength > 0)
            {
                try
                {
                    using (var package = new ExcelPackage(archivo.InputStream))
                    {
                        var worksheet = package.Workbook.Worksheets[0]; // Obtén la primera hoja del archivo
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++) // Suponiendo que la primera fila es el encabezado
                        {
                            var cliente = new Cliente
                            {
                                Paja = int.TryParse(worksheet.Cells[row, 1].Text, out int paja) ? paja : (int?)null,
                                Nombre = worksheet.Cells[row, 2].Text,
                                Telefono = worksheet.Cells[row, 3].Text,
                                Direccion = worksheet.Cells[row, 4].Text,
                                Correo = worksheet.Cells[row, 5].Text,
                                Cedula = int.TryParse(worksheet.Cells[row, 6].Text, out int cedula) ? cedula : (int?)null,
                                Sector = worksheet.Cells[row, 7].Text
                            };

                            // Guarda el cliente en la base de datos
                            new CN_Cliente().Registrar(cliente, out mensaje);
                        }
                    }
                    return Json(new { success = true, message = "Clientes importados exitosamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = ex.Message });
                }
            }
            return Json(new { success = false, message = "No se ha seleccionado un archivo." });
        }

        [HttpPost]
        public JsonResult GuardarCliente(Cliente objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdCliente == 0)
            {
                resultado = new CN_Cliente().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Cliente().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarCliente(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Cliente().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        //USUARIOS
        #region
        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> oLista = new List<Usuario>();
            oLista = new CN_Usuarios().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarUsuario(Usuario objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdUsuario == 0)
            {
                resultado = new CN_Usuarios().Registrar(objeto, out mensaje);

            }
            else
            {
                resultado = new CN_Usuarios().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Usuarios().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        
        
    }
}