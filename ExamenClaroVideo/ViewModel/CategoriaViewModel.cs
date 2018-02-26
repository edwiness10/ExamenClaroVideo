using ExamenClaroVideo.DataTypes;
using ExamenClaroVideo.Infrastructure;
using ExamenClaroVideo.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace ExamenClaroVideo.ViewModel
{
    public class CategoriaViewModel : ViewModelBase
    {

        private ObservableCollection <PeliculaDetalleType> _listaPeliculas;
        private ServiceNavigation _serviceNavigation;
        private IBussinesLayer bussinesLayer;
        private PeliculaDetalleType _elementoMenu;
        private ICommand _pageLoadedCommand;


        public ObservableCollection<PeliculaDetalleType> ListaPeliculas
        {
            get { return _listaPeliculas; }
            set
            {
                if (value != _listaPeliculas)
                {
                    _listaPeliculas = value;
                    RaisePropertyChanged(() => ListaPeliculas);
                }
            }
        }
        public PeliculaDetalleType ElementoMenu
        {
            get { return _elementoMenu; }
            set
            {
                if (value != _elementoMenu)
                {
                    _elementoMenu = value;
                    MenuOpcion(_elementoMenu);
                    RaisePropertyChanged(() => ElementoMenu);
                }

            }
        }
        public ICommand PageLoadedCommand
        {
            get
            {
                if (_pageLoadedCommand == null)
                {
                    _pageLoadedCommand = new RelayCommand(CargarDatos);
                }
                return _pageLoadedCommand;
            }
        }
        public CategoriaViewModel(ServiceNavigation serviceNavigation, IBussinesLayer bussinesLayer)
        {
            this._serviceNavigation = serviceNavigation;
            this.bussinesLayer = bussinesLayer;
        }
        public void MenuOpcion(PeliculaDetalleType _elementoMenu)
        {
            if (_elementoMenu!=null)
            {
                bussinesLayer.PeliculaActualSet(_elementoMenu);
                _serviceNavigation.Navigate(typeof(DetallePage));
                ElementoMenu = null;
            }
        }
        private async void CargarDatos()
        {
            if (ListaPeliculas==null)
            {
                ListaPeliculas = await bussinesLayer.DameListaPelis();
                if (ListaPeliculas.Count()==0)
                {
                    ListaPeliculas = null;
                }
            }
            
        }
        
    }
}
