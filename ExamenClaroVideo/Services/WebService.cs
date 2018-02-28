using ExamenClaroVideo.DataLayer.Entities;
using ExamenClaroVideo.DataTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace ExamenClaroVideo.Services
{
    public class WebService : IWebService
    {
        private string _url;
        public string UrlGet()
        {
            return _url;
        }
        public void UrlSet(string _url)
        {
            this._url = _url;
        }
        public WebService()
        {
            AsignarUrlResource();
        } 
        public async Task<ObservableCollection<Db_Peliculas>> ObtenerListaPeliculas()
        {
            try
            {
                if (_url != null && _url !="")
                {
                    var httpClient = new HttpClient()
                    {
                        Timeout = new TimeSpan(0, 1, 0),
                        BaseAddress = new Uri(_url)
                    };
                    var resultPeticion = await httpClient.GetAsync("0");
                    var resultadoCodigo = resultPeticion.EnsureSuccessStatusCode();
                    var listaPeliculas = resultPeticion.Content.ReadAsStringAsync().Result;
                    ObservableCollection<Db_Peliculas> results = JsonConvert.DeserializeObject<ObservableCollection<Db_Peliculas>>(listaPeliculas);
                    if (!resultadoCodigo.IsSuccessStatusCode)
                    {
                        return new ObservableCollection<Db_Peliculas>();
                    }
                    return results;
                }
                return new ObservableCollection<Db_Peliculas>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new ObservableCollection<Db_Peliculas>();
            }
        }
        public async Task<Db_Peliculas> ObtenerPelicula(int idPelicula)
        {
            try
            {
                if (_url != null && _url != "")
                {
                    var httpClient = new HttpClient()
                    {
                        Timeout = new TimeSpan(0, 1, 0),
                        BaseAddress = new Uri(_url)
                    };
                    var resultPeticion = await httpClient.GetAsync(idPelicula.ToString());
                    var resultadoCodigo = resultPeticion.EnsureSuccessStatusCode();
                    var listaPeliculas = resultPeticion.Content.ReadAsStringAsync().Result;
                    var listaResult = JsonConvert.DeserializeObject<ObservableCollection<Db_Peliculas>>(listaPeliculas);
                    Db_Peliculas results = listaResult.FirstOrDefault();
                    if (!resultadoCodigo.IsSuccessStatusCode)
                    {
                        return new Db_Peliculas();
                    }
                    return results;
                }
                return new Db_Peliculas();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new Db_Peliculas();
            }
        }
        private bool AsignarUrlResource()
        {
            try
            {
                var loader = new ResourceLoader();
                if (loader != null)
                {
                    _url = loader.GetString("ConexionWebService");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

    }
}
