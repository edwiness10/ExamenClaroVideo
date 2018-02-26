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
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace ExamenClaroVideo.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {

        #region "Variables Etc"
        public  ServiceNavigation Navigate { get; private set; }
        private IBussinesLayer bussinesLayer;
        private ICommand _comandoAbrirMenu;
        private ICommand _pageLoadedCommand;
        private ICommand _comandoItemInvoked;
        private bool _isOpenMenu;        
        private object _frameAplicacion;
        private string _textoEstadoInternet;        
        private ObservableCollection<SplitViewPaneMenuItem> _menuItems;
        private SplitViewPaneMenuItem _selectMenu;
        
        private ICommand _textChangedCommand;
        private ICommand _querySubmittedCommand;

        private string _textoBuscador;
        private ObservableCollection<PeliculaDetalleType> _listaResultado;


        #endregion
        #region "Propiedades"
        public ICommand ComandoAbrirMenu
        {
            get
            {
                if (_comandoAbrirMenu == null)
                {
                    _comandoAbrirMenu = new RelayCommand(AbrirMenu);
                }
                return _comandoAbrirMenu;
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
        public ICommand ComandoItemInvoked
        {
            get
            {
                if (_comandoItemInvoked == null)
                {
                    _comandoItemInvoked = new RelayCommand(MenuNavegarTo);
                }
                return _comandoItemInvoked;
            }
        }
        public ObservableCollection<SplitViewPaneMenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                if (value != _menuItems)
                {
                    _menuItems = value;
                    RaisePropertyChanged(() => MenuItems);
                }
            }
        }
        public SplitViewPaneMenuItem SelectMenu
        {
            get { return _selectMenu; }
            set
            {
                if (value != _selectMenu)
                {
                    _selectMenu = value;                    
                    RaisePropertyChanged(() => SelectMenu);
                }
            }
        }
        public bool IsOpenMenu
        {
            get { return _isOpenMenu; }
            set
            {
                if (value != _isOpenMenu)
                {
                    _isOpenMenu = value;
                    RaisePropertyChanged(() => IsOpenMenu);
                }

            }
        }
        public object FrameAplicacion
        {
            get { return _frameAplicacion; }
            set
            {
                if (value != _frameAplicacion)
                {
                    _frameAplicacion = value;
                    RaisePropertyChanged(() => FrameAplicacion);
                }
            }
        }
        public ICommand TextChangedCommand
        {
            get
            {
                if (_textChangedCommand == null)
                {
                    _textChangedCommand = new RelayCommand<object>(TextChanged);
                }
                return _textChangedCommand;
            }
        }
        public ICommand QuerySubmittedCommand
        {
            get
            {
                if (_querySubmittedCommand == null)
                {
                   // _querySubmittedCommand = new RelayCommand<object>(QuerySubmittedChanged);
                    _querySubmittedCommand = new RelayCommand<AutoSuggestBoxQuerySubmittedEventArgs>(QuerySubmittedChanged);
                }
                return _querySubmittedCommand;
            }
        }
        public string TextoBuscador
        {
            get { return _textoBuscador; }
            set
            {
                if (value != _textoBuscador)
                {
                    _textoBuscador = value;
                    RaisePropertyChanged(() => TextoBuscador);
                }

            }
        }
        public string TextoEstadoInternet
        {
            get { return _textoEstadoInternet; }
            set
            {
                if (value != _textoEstadoInternet)
                {
                    _textoEstadoInternet = value;
                    RaisePropertyChanged(() => TextoEstadoInternet);
                }
            }
        }
        public ObservableCollection<PeliculaDetalleType> ListaResultado
        {
            get { return _listaResultado; }
            set
            {
                if (value != _listaResultado)
                {
                    _listaResultado = value;
                    RaisePropertyChanged(() => ListaResultado);
                }
            }
        }

        #endregion

        #region "Constructor Etc"
        public MainPageViewModel(ServiceNavigation navigate, IBussinesLayer bussinesLayer)
        {
            this.Navigate = navigate;
            this.bussinesLayer = bussinesLayer;
            EstadoConexion();


        }
        private void EstadoConexion()
        {
            bussinesLayer.EventoCambioEstadoInternet += BussinesLayer_EventoCambioEstadoInternet;
            CambioEstado(bussinesLayer.HayInternet());

        }

        private void BussinesLayer_EventoCambioEstadoInternet(object sender, bool e)
        {
            CambioEstado(e);
        }
        private async void CambioEstado(bool estado)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                 () =>
                 {
                     if (estado)
                     {
                         TextoEstadoInternet = "Online";
                     }
                     else
                     {
                         TextoEstadoInternet = "Offline";
                     }
                 });            
        }

        #endregion
        #region "Procedimientos Internos"

        private void AbrirMenu()
        {
            IsOpenMenu = !IsOpenMenu;
        }
        private void CargarDatos()
        {
            CargarMenu();
        }
        private void CargarMenu()
        {
            MenuItems = new ObservableCollection<SplitViewPaneMenuItem>
            {
                new SplitViewPaneMenuItem
                {
                    Label = "Categoria",
                    Icono=Symbol.Home,
                    AssociatedPage = typeof(CategoriaPage)
                }
            };
        }
        private void MenuNavegarTo( )
        {
            if (SelectMenu != null && SelectMenu.AssociatedPage!=null)
            {
                Navigate.NavigateTo(SelectMenu.AssociatedPage,null);
                SelectMenu = null;
            }
            
        }

        private async void TextChanged(object data)
        {
            ListaResultado= await bussinesLayer.BuscarPelicula(TextoBuscador);
        }
        private  void QuerySubmittedChanged(AutoSuggestBoxQuerySubmittedEventArgs data)
        {
            
            if (data.ChosenSuggestion != null)
            {
                bussinesLayer.PeliculaActualSet((PeliculaDetalleType)data.ChosenSuggestion);
                Navigate.Navigate(typeof(DetallePage));
                TextoBuscador = "";
                ListaResultado = null;
            }           
            //ListaResultado = await bussinesLayer.BuscarPelicula(TextoBuscador);
        }
        #endregion

    }
}
