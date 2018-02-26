using ExamenClaroVideo.DataLayer.Entities;
using ExamenClaroVideo.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenClaroVideo.Services
{
    public interface IWebService
    {
        string UrlGet();
        void UrlSet(string _url);
        Task<Db_Peliculas> ObtenerPelicula(int idPelicula);
        Task<ObservableCollection<Db_Peliculas>> ObtenerListaPeliculas();
    }
}
