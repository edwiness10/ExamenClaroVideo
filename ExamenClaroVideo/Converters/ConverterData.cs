using ExamenClaroVideo.DataLayer.Entities;
using ExamenClaroVideo.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenClaroVideo.Converters
{
    public class ConverterData
    {
        public static PeliculaDetalleType ConvertePeliculasToType(Db_Peliculas db_Peliculas)
        {
            PeliculaDetalleType datoConvertido =new PeliculaDetalleType();
            if (db_Peliculas!=null)
            {
                List<string> listGenero = new List<string>();
                List<string> listDirector = new List<string>();
                List<string> listEscritor = new List<string>();
                List<string> listProductor = new List<string>();
                List<string> listActor = new List<string>();
                if (db_Peliculas.Genero != null)
                {
                     listGenero = db_Peliculas.Genero.Split(',').ToList();
                }
                if (db_Peliculas.Director !=null)
                {
                     listDirector = db_Peliculas.Director.Split(',').ToList();
                }
                if (db_Peliculas.Escritor != null)
                {
                     listEscritor = db_Peliculas.Escritor.Split(',').ToList();
                }
                if (db_Peliculas.Productor != null)
                {
                     listProductor = db_Peliculas.Productor.Split(',').ToList();
                }
                if (db_Peliculas.Actor != null)
                {
                    listActor = db_Peliculas.Actor.Split(',').ToList();
                }
                datoConvertido = new PeliculaDetalleType {
                    Id= db_Peliculas.Id,
                    Titulo=db_Peliculas.Titulo,
                    Descripcion=db_Peliculas.Descripcion,
                    Duracion=db_Peliculas.Duracion,
                    Clasificacion=db_Peliculas.Clasificacion,
                    UrlImagen=db_Peliculas.UrlImagen,
                    RutaImagen=db_Peliculas.RutaImagen,
                    Genero= listGenero,
                    Actor= listActor,
                    Director = listDirector,
                    Escritor= listEscritor ,
                    Productor= listProductor,
                    UrlVideo=db_Peliculas.UrlVideo,
                    VideoLocal=db_Peliculas.VideoLocal
                    };
            }
            return datoConvertido;
        }
        public static ObservableCollection<PeliculaDetalleType> ConverteCollectionPeliculasToType(ObservableCollection<Db_Peliculas> db_coleccionPeliculas)
        {
            ObservableCollection<PeliculaDetalleType> coleccionConvertida = new ObservableCollection<PeliculaDetalleType>();
            foreach (var item in db_coleccionPeliculas)
            {
                coleccionConvertida.Add(ConvertePeliculasToType(item));
            }          
            return coleccionConvertida;
        }
        public static Db_Peliculas ConvertePeliculasToDb(PeliculaDetalleType Peliculas)
        {
            Db_Peliculas datoConvertido = new Db_Peliculas();
            if (Peliculas != null)
            {
                var listGenero = String.Join(",", Peliculas.Genero);
                var listActor = String.Join(",", Peliculas.Actor);
                var listDirector = String.Join(",", Peliculas.Director);
                var listEscritor = String.Join(",", Peliculas.Escritor);
                var listProductor = String.Join(",", Peliculas.Productor);
                datoConvertido = new Db_Peliculas
                {
                    Id = Peliculas.Id,
                    Titulo = Peliculas.Titulo,
                    Descripcion = Peliculas.Descripcion,
                    Duracion = Peliculas.Duracion,
                    Clasificacion = Peliculas.Clasificacion,
                    UrlImagen = Peliculas.UrlImagen,
                    RutaImagen = Peliculas.RutaImagen,
                    Genero = listGenero,
                    Actor = listActor,
                    Director = listDirector,
                    Escritor = listEscritor,
                    Productor = listProductor,
                    UrlVideo = Peliculas.UrlVideo,
                    VideoLocal = Peliculas.VideoLocal
                };
            }
            return datoConvertido;
        }
        public static ObservableCollection<Db_Peliculas> ConverteCollectionPeliculasToDb(ObservableCollection<PeliculaDetalleType> db_coleccionPeliculas)
        {
            ObservableCollection<Db_Peliculas> coleccionConvertida = new ObservableCollection<Db_Peliculas>();
            foreach (var item in db_coleccionPeliculas)
            {
                coleccionConvertida.Add(ConvertePeliculasToDb(item));
            }
            return coleccionConvertida;
        }
    }
}
