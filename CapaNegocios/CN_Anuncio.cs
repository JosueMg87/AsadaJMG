﻿using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Anuncio
    {
        private CD_Anuncio objCapaDato = new CD_Anuncio();

        public List<Anuncio> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Anuncio obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Titulo) || string.IsNullOrWhiteSpace(obj.Titulo))
            {
                Mensaje = "El Titulo del Anuncio no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion del Anuncio no puede ser vacio";
            }
            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0;
            }
            return objCapaDato.Registrar(obj, out Mensaje);
        }

        public bool Editar(Anuncio obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Titulo) || string.IsNullOrWhiteSpace(obj.Titulo))
            {
                Mensaje = "El Titulo del Anuncio no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion del Anuncio no puede ser vacio";
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

        public bool GuardarDatosImagen(Anuncio obj, out string Mensaje)
        {
            return objCapaDato.GuardarDatosImagen(obj, out Mensaje);
        }


    }
}
