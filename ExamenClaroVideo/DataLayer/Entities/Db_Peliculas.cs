using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenClaroVideo.DataLayer.Entities
{
    public class Db_Peliculas
    {
        public int Id { get; set; }
        public int Estado { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public string Clasificacion { get; set; }
        public string UrlImagen { get; set; }
        public string RutaImagen { get; set; }
        public string Genero { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }
        public string Escritor { get; set; }
        public string Productor { get; set; }
        public string TítuloOriginal { get; set; }
        public string UrlVideo { get; set; }
        public string VideoLocal { get; set; }
    }
}
