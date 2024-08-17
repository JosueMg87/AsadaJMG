using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Anuncio
    {
        public int IdAnuncio { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string RutaImagen { get; set; }

        public string NombreImagen { get; set; }
        //imagen
        public string Base64 { get; set; }

        public string Extension { get; set; }
    }
}
