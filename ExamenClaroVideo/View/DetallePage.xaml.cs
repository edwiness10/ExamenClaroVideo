using ExamenClaroVideo.DataTypes;
using ExamenClaroVideo.Infrastructure;
using ExamenClaroVideo.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace ExamenClaroVideo
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class DetallePage : Page
    {
        public DetallePage()
        {
            this.InitializeComponent();
           // this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter!=null)
            {
                if (e.Parameter is PeliculaDetalleType)
                {
                    ViewModelLocator.Detalle.PeliculaActual = (PeliculaDetalleType)e.Parameter;
                }  
            }
        }
    }
}
