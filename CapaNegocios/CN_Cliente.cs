using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Cliente
    {
        private CD_Cliente objCapaDato = new CD_Cliente();

        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del Cliente no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje = "La Direccion del Cliente no puede ser vacia";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El Correo del Cliente no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Sector) || string.IsNullOrWhiteSpace(obj.Sector))
            {
                Mensaje = "El Sector del Cliente no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje = "El Telefono del Cliente no puede ser vacio";
            }
            else if (obj.Paja == null) // Verificación para el campo Paja que es int
            {
                Mensaje = "La Paja del Cliente no puede ser vacía o menor o igual a cero";
            }

            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0; 
            }

            return objCapaDato.Registrar(obj, out Mensaje);
        }

        public List<Cliente> Listar()
        {
            return objCapaDato.Listar();
        }

        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del Cliente no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje = "La Direccion del Cliente no puede ser vacia";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El Correo del Cliente no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Sector) || string.IsNullOrWhiteSpace(obj.Sector))
            {
                Mensaje = "El Sector del Cliente no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje = "El Telefono del Cliente no puede ser vacio";
            }

            return objCapaDato.Editar(obj, out Mensaje);

        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }










    }
}
