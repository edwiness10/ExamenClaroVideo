using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenClaroVideo.DataLayer.Entities
{
    public class Db_RelacionCatPel
    {
        public int Id { get; set; }

        [ForeignKey("PeliculaId")]
        public Db_Peliculas Pelicula { get; set; }
        [ForeignKey("CategoriaId")]
        public Db_Categoria Categoria { get; set; }

    }
}
