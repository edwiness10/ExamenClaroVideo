using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenClaroVideo.DataLayer.Entities;

namespace ExamenClaroVideo.DataLayer
{
    //Add-Migration MigracionClaroVideo
    //Remove-Migration  
    public class DatosContext : DbContext
    {
        public DbSet<Db_Categoria> Categoria { get; set; }
        public DbSet<Db_Peliculas> Peliculas { get; set; }
        public DbSet<Db_RelacionCatPel> RelacionCatPel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=DbClaro.db");
        }
    }
}
