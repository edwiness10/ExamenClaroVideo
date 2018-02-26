using ExamenClaroVideo.DataTypes;
using ExamenClaroVideo.Infrastructure;
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

namespace ExamenClaroVideo.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {

        #region "Variables Etc"
        public ServiceNavigation Navigate { get; private set; }
        private ICommand _comandoAbrirMenu;
        private ICommand _pageLoadedCommand;
        private ICommand _comandoItemInvoked;
        private bool _isOpenMenu;        
        private object _frameAplicacion;
        private ObservableCollection<SplitViewPaneMenuItem> _menuItems;
        private SplitViewPaneMenuItem _selectMenu;


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

        #endregion

        #region "Constructor Etc"
        public MainPageViewModel(ServiceNavigation navigate)
        {
            this.Navigate = navigate;
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
        #endregion

    }
}
