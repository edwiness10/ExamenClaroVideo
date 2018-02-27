using ExamenClaroVideo.Converters;
using ExamenClaroVideo.DataLayer;
using ExamenClaroVideo.DataLayer.Entities;
using ExamenClaroVideo.DataTypes;
using ExamenClaroVideo.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace ExamenClaroVideo.Model
{
    public class BussinesLayer : IBussinesLayer
    {
        private IDataRepository dataRepository;
        private IWebService webService;
        private PeliculaDetalleType _peliculaActual;
        private bool _hayInternet;
        public event EventHandler<bool> EventoCambioEstadoInternet;

        public BussinesLayer(IDataRepository dataRepository, IWebService webService)
        {
            this.dataRepository = dataRepository;
            this.webService = webService;
            MonitorearInternet();
        }
        public bool HayInternet()
        {
            var x = NetworkInformation.GetInternetConnectionProfile();
            if (x != null)
            {
                _hayInternet = true;
                return true;
            }
            else
            {
                _hayInternet = false;
                return false;
            }           
        }
        public void MonitorearInternet()
        {
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
            HayInternet();
        }

        private void NetworkInformation_NetworkStatusChanged(object sender)
        {
            EventoCambioEstadoInternet?.Invoke(this, HayInternet());
        }        

        public async Task <ObservableCollection<PeliculaDetalleType>> DameListaPelis()
        {
            ObservableCollection<Db_Peliculas> datosRetorno= new ObservableCollection<Db_Peliculas>();
            if (HayInternet())
            {
                 datosRetorno = await webService.ObtenerListaPeliculas();
                if (datosRetorno != null)
                {
                    Task.Factory.StartNew(() =>
                    {
                        dataRepository.GuardarListaPeliculas(datosRetorno);
                    });
                }
            }
            else
            {
                datosRetorno = dataRepository.DameListaPeliculas();
            }
            return ConverterData.ConverteCollectionPeliculasToType(datosRetorno);
        }

        public async Task<ObservableCollection<PeliculaDetalleType>> BuscarPelicula(string peliculaBuscar)
        {
            ObservableCollection < Db_Peliculas > datosRetorno = new ObservableCollection<Db_Peliculas> ();
            if (_hayInternet)
            {
                 datosRetorno = await webService.ObtenerListaPeliculas();
            }
            else
            {
                datosRetorno =  dataRepository.DameListaPeliculas();
            }
           
            ObservableCollection<Db_Peliculas> nuevo = new ObservableCollection<Db_Peliculas>();
            if (datosRetorno!=null)
            {
                nuevo = new ObservableCollection<Db_Peliculas> (datosRetorno.Where(x=>x.Titulo.ToUpper().Contains(peliculaBuscar.ToUpper())));
            }
            return ConverterData.ConverteCollectionPeliculasToType(nuevo);
        }

        public void PeliculaActualSet(PeliculaDetalleType peliculaActual)
        {
            _peliculaActual = peliculaActual;
        }
        public PeliculaDetalleType PeliculaActualGet()
        {
            return _peliculaActual;
        }

        public bool HayDatosOffline()
        {
            return dataRepository.HayDatosOffline();
        }
    }
    
}
