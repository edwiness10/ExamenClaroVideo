using ExamenClaroVideo.DataLayer;
using ExamenClaroVideo.DataTypes;
using ExamenClaroVideo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public BussinesLayer(IDataRepository dataRepository, IWebService webService)
        {
            this.dataRepository = dataRepository;
            this.webService = webService;
            webService.ObtenerListaPeliculas();
            webService.ObtenerPelicula(2);
            
        }
        public bool HayInternet()
        {
            var x = NetworkInformation.GetInternetConnectionProfile();
            if (x != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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

            }
        }

        public async Task <ObservableCollection<PeliculaDetalleType>> DameListaPelis()
        {
            //Download("");
            StartDownload_Click();
            var datosRetorno = await webService.ObtenerListaPeliculas();
            dataRepository.GuardarListaPeliculas(datosRetorno);
            return ConverterData.ConverteCollectionPeliculasToType(datosRetorno);
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
