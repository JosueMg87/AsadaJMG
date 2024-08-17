using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Historial
    {
        private CD_Historial objCapaDato = new CD_Historial();

        public List<Historial> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Historial obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Titulo) || string.IsNullOrWhiteSpace(obj.Titulo))
            {
                Mensaje = "El Titulo del Historial no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion del Historial no puede ser vacio";
            }

            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0;  // Retorna 0 si hay un error
            }

            return objCapaDato.Registrar(obj, out Mensaje);
        }

        public bool Editar(Historial obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Titulo) || string.IsNullOrWhiteSpace(obj.Titulo))
            {
                Mensaje = "El Titulo del Historial no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion del Historial no puede ser vacio";
            }

            if (!string.IsNullOrEmpty(Mensaje))
            {
                return false;  // Retorna false si hay un error
            }

            return objCapaDato.Editar(obj, out Mensaje);
        }


        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }

        public bool GuardarDatosImagen(Historial obj, out string Mensaje)
        {
            return objCapaDato.GuardarDatosImagen(obj, out Mensaje);
        }

    }
}
