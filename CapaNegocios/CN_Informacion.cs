using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Informacion
    {
        private CD_Informacion objCapaDato = new CD_Informacion();

        public List<Informacion> Listar()
        {
            return objCapaDato.Listar();
        }

        public Informacion ObtenerPorId(int id)
        {
            return objCapaDato.ObtenerPorId(id);
        }

        public int Registrar(Informacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre de la información no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion de la información no puede ser vacia";
            }
            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0;
            }
            return objCapaDato.Registrar(obj, out Mensaje);
        }

        public bool Editar(Informacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre de la asada no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion de la asada no puede ser vacia";
            }
            if (!string.IsNullOrEmpty(Mensaje))
            {
                return false;
            }
            return objCapaDato.Editar(obj, out Mensaje);
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
