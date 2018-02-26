using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenClaroVideo.DataLayer.Entities
{
   public  class Db_Categoria
   {
        public int Id { get; set; }
        public int Estado { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
    }
}
