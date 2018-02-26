using ExamenClaroVideo.DataLayer;
using ExamenClaroVideo.DataLayer.Entities;
using ExamenClaroVideo.DataTypes;
using ExamenClaroVideo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Networking.Connectivity;
using Windows.Storage;

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

        private async void StartDownload_Click()
        {
            try
            {
                Uri source = new Uri("https://pruebasweb943415831.files.wordpress.com/2018/02/ghostrider2007whorizontal.jpg");              

                string destination = "DatoTemporal.jpg";

                StorageFolder destinationFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Thumbnail",CreationCollisionOption.OpenIfExists);
                //FolderRelativeId = "-1745770124\\30650028\\DatoTemporal.jpg"
                StorageFile destinationFile = await destinationFolder.CreateFileAsync(
                    destination, CreationCollisionOption.ReplaceExisting);

                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(source, destinationFile);
                try
                {
                    await download.StartAsync().AsTask();
                }
                catch (TaskCanceledException)
                {
                    await download.ResultFile.DeleteAsync();
                    download = null;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task <ObservableCollection<PeliculaDetalleType>> DameListaPelis()
        {
            ////Download("");
            //StartDownload_Click();
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
    }
}
